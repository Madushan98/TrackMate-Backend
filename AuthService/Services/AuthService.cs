using System.Security.Claims;
using AutoMapper;
using BaseService.DataContext;
using BaseService.Services;
using DAOLIbrary.User;
using DTOLibrary.Exceptions;
using DTOLibrary.UserDto;
using DTOLibrary.UserDto.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;

namespace AuthService.Services;

public class AuthService : IAuthService
{
    private readonly DBContext _context;
    private readonly IMapper _mapper;
    private readonly ICryptoService _cryptoService;
    private readonly ITokenService _tokenService;

    public AuthService(DBContext context, IMapper mapper, ICryptoService cryptoService, ITokenService tokenService)
    {
        _context = context;
        _mapper = mapper;
        _cryptoService = cryptoService;
        _tokenService = tokenService;
    }

    public async Task<UserResponse> RegisterUserAsync(CreateUserRequest createUserRequest)
    {
        var userExist = await GetUserByNationIdAsync(createUserRequest.NationalId);

        if (userExist != null)
        {
            throw new BadRequestException(CommonExceptions.NationalIdAlreadyRegistered);
        }

        var userDao = _mapper.Map<User>(createUserRequest);
        var (encryptedPassword, key, iv) = _cryptoService.Encrypt(createUserRequest.Password);
        userDao.Password = encryptedPassword;
        userDao.Key = key;
        userDao.Iv = iv;
        userDao.IsVertified = false;
        var entityEntry = await _context.Users.AddAsync(userDao);
        var saveAsync = await _context.SaveChangesAsync();

        return _mapper.Map<UserResponse>(userDao);
    }

    public async Task<LoginResponse> LoginUserAsync(LoginRequest loginRequest)
    {
        var userDao = await GetUserByNationIdAsync(loginRequest.NationalId);
        if (userDao == null)
        {
            throw new NotFoundException(CommonExceptions.UserNotFound);
        }

        var decryptPassword = _cryptoService.Decrypt(userDao.Password, userDao.Key, userDao.Iv);

        if (loginRequest.Password != decryptPassword)
        {
            throw new NotFoundException(CommonExceptions.UserPasswordMisMatch);
        }

        var refreshToken = Guid.NewGuid().ToString();
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userDao.NationalId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("UserId", userDao.UserId.ToString()),
            new Claim("Username", userDao.NationalId),
            new Claim("Permission", string.Join(",", new List<int>())),
        };

        var userResponse = _mapper.Map<UserResponse>(userDao);

        return _tokenService.GenerateAuthenticationResult(userDao.UserId.ToString(), claims, refreshToken,
            userResponse);
    }

    private async Task<User?> GetUserByNationIdAsync(string nationalId)
    {
        var firstOrDefaultAsync = await _context.Users.AsNoTracking().Where(user => user.NationalId == nationalId)
            .FirstOrDefaultAsync();

        return firstOrDefaultAsync;
    }
}