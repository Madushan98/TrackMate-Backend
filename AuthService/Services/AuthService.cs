using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using AutoMapper;
using BaseService.Constants;
using BaseService.DataContext;
using BaseService.Services;
using DAOLibrary.User;
using DTOLibrary.Exceptions;
using DTOLibrary.UserDto;
using DTOLibrary.UserDto.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Net.Http;
using DAOLibrary.Organization;
using DTOLibrary.OrganizationDto;
using DTOLibrary.OrganizationDto.Login;

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

    public async Task<LoginResponse> RegisterUserAsync(CreateUserRequest createUserRequest)
    {
        var userExist = await GetUserByNationIdAsync(createUserRequest.NationalId);

        if (userExist != null)
        {
            throw new BadHttpRequestException(CommonExceptions.NationalIdAlreadyRegistered.Message, 400);
        }

        var userDao = _mapper.Map<UserDao>(createUserRequest);
        var (encryptedPassword, key, iv) = _cryptoService.Encrypt(createUserRequest.Password);
        userDao.Password = encryptedPassword;
        userDao.Key = key;
        userDao.Iv = iv;
        userDao.UserType = Constants.UserTypes[Constants.UserUserRole];

        var entityEntry = await _context.Users.AddAsync(userDao);
        var saveAsync = await _context.SaveChangesAsync();

        var userResponse = _mapper.Map<UserResponse>(userDao);
        var refreshToken = Guid.NewGuid().ToString();
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userDao.NationalId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("UserId", userDao.Id.ToString()),
            new Claim("Username", userDao.NationalId),
            new Claim("Permission", string.Join(",", new List<int>())),
            new Claim("UserType", userDao.UserType)
        };
        return _tokenService.GenerateAuthenticationResult(userDao.Id.ToString(), claims, refreshToken,
            userResponse);
    }
    
    public async Task<OrganizationLoginResponse> RegisterOrganization(CreateOrganizationRequest organizationRequest)
    {
        
        bool checkExists = await IsOrganizationExists(organizationRequest);
        if (checkExists)
        {
            return null;
        }
        var organizationDao = _mapper.Map<OrganizationDao>(organizationRequest);
        var (encryptedPassword, key, iv) = _cryptoService.Encrypt(organizationRequest.Password);
        organizationDao.IsApproved = false;
        organizationDao.Iv = iv;
        organizationDao.Key = key;
        organizationDao.Password = encryptedPassword;
        organizationDao.UserType = Constants.UserTypes[Constants.UserOrganizationRole];
        var organization = await _context.Organizations.AddAsync(organizationDao);
        var organizationResponse = _mapper.Map<OrganizationResponse>(organizationDao);
        var saveAsync = await _context.SaveChangesAsync();
        var refreshToken = Guid.NewGuid().ToString();
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, organizationDao.EmailAddress),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("UserId", organization.Entity.Id.ToString()),
            new Claim("Username", organizationDao.EmailAddress),
            new Claim("Permission", string.Join(",", new List<int>())),
            new Claim("UserType",organizationDao.UserType )
        };
        return _tokenService.GenerateOrganizationAuthenticationResult(organization.Entity.Id.ToString(), claims,
            refreshToken, organizationResponse);
    }

    public async Task<OrganizationLoginResponse> LoginOrganization(LoginOrganizationRequest loginOrganizationRequest)
    {
        var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.EmailAddress == loginOrganizationRequest.EmailAddress);
        if (organization == null)
        {
            throw new ValidationException("Organization is not registered");
        }
        var decryptedPassword = _cryptoService.Decrypt(organization.Password, organization.Key, organization.Iv);
        if (decryptedPassword != loginOrganizationRequest.Password)
        {
            throw new ValidationException("Password is incorrect");
        }
        var organizationResponse = _mapper.Map<OrganizationResponse>(organization);
        var refreshToken = Guid.NewGuid().ToString();
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, organization.EmailAddress),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("UserId", organization.Id.ToString()),
            new Claim("Username", organization.EmailAddress),
            new Claim("Permission", string.Join(",", new List<int>())),
            new Claim("UserType", organization.UserType)
        };
        return _tokenService.GenerateOrganizationAuthenticationResult(organization.Id.ToString(), claims,
            refreshToken, organizationResponse);
    }
    public async Task<LoginResponse> LoginUserAsync(LoginRequest loginRequest)
    {
        var userDao = await GetUserByNationIdAsync(loginRequest.NationalId);
        if (userDao == null)
        {
            throw new BadHttpRequestException(CommonExceptions.UserNotFound.Message, 400);
        }

        var decryptPassword = _cryptoService.Decrypt(userDao.Password, userDao.Key, userDao.Iv);

        if (loginRequest.Password != decryptPassword)
        {
            throw new BadHttpRequestException("Credentials are Wrong", 401);
        }

        var refreshToken = Guid.NewGuid().ToString();
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userDao.NationalId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("UserId", userDao.Id.ToString()),
            new Claim("Username", userDao.NationalId),
            new Claim("Permission", string.Join(",", new List<int>())),
            new Claim("UserType", userDao.UserType)
        };

        var userResponse = _mapper.Map<UserResponse>(userDao);

        return _tokenService.GenerateAuthenticationResult(userDao.Id.ToString(), claims, refreshToken,
            userResponse);
    }

    
    private async Task<UserDao?> GetUserByNationIdAsync(string nationalId)
    {
        var firstOrDefaultAsync = await _context.Users.AsNoTracking().Where(user => user.NationalId == nationalId)
            .FirstOrDefaultAsync();

        return firstOrDefaultAsync;
    }
    
    private async Task<bool> IsOrganizationExists(CreateOrganizationRequest organizationRequest)
    {
        if (string.IsNullOrEmpty(organizationRequest.EmailAddress))
        {
            return false;
        }

        var firstOrDefault =await _context.Organizations.AsNoTracking()
            .Where(org => org.EmailAddress.Equals(organizationRequest.EmailAddress)).FirstOrDefaultAsync();
        return firstOrDefault != null;
    }
}