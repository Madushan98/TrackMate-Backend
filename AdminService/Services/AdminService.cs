using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using AuthService.Domain.Filters;
using AutoMapper;
using BaseService.Constants;
using BaseService.DataContext;
using BaseService.Services;
using DAOLibrary.User;
using DTOLibrary.Common;
using DTOLibrary.Exceptions;
using DTOLibrary.Helpers;
using DTOLibrary.UserDto;
using DTOLibrary.UserDto.AddOrganization;
using Microsoft.EntityFrameworkCore;

namespace AdminService.Services;

public class UserService : IUserService
{
    private readonly DBContext _context;
    private readonly IMapper _mapper;
    private readonly ICryptoService _cryptoService;


    public UserService(DBContext context, IMapper mapper,ICryptoService cryptoService)
    {
        _context = context;
        _mapper = mapper;
        _cryptoService = cryptoService;
    }

    public async Task<PagedResponse<UserResponse>> GetAllUsersAsync(UserFilter filter,
        PaginationFilter pagination)
    {
        var queryable = _context.Users.AsNoTracking();

        queryable = AddFilterOnQuery(filter, queryable);

        var pagedResponse = await PagedResponse<UserDao>.ToPagedList(queryable, pagination);
        return MappingHelper.MapPagination<UserResponse, UserDao>(pagedResponse, _mapper);
    }
    


    private IQueryable<UserDao> AddFilterOnQuery(UserFilter filter, IQueryable<UserDao> queryable)
    {
        if (Guid.Empty != filter?.UserId)
        {
            queryable = queryable.Where(user => user.Id == filter.UserId);
        }

        if (!string.IsNullOrEmpty(filter?.NationalId))
        {
            queryable = queryable.Where(user => user.NationalId.StartsWith(filter.NationalId));
        }

        return queryable;
    }

    public async Task<UserResponse> CreateUserAsync(CreateUserRequest createUserRequest)
    {
        if (await GetUserByNationIdAsync(createUserRequest.NationalId) != null)
            throw new ValidationException("User With Same NationalCardId Already Exists");

        var user = _mapper.Map<UserDao>(createUserRequest);
        

        var entityEntry = await _context.Users.AddAsync(user);
        var saveChangesAsync = await _context.SaveChangesAsync();
        if (saveChangesAsync > 0)
        {
            var userByIdAsync = await GetUserByIdAsync(entityEntry.Entity.Id);
            return _mapper.Map<UserResponse>(userByIdAsync);
        }

        return null;
        ;
    }
    
    public async Task<UserResponse> GetUserByIdAsync(Guid userId)
    {
        var result = await GetUserDaoByIdAsync(userId);
        var userResponse = _mapper.Map<UserResponse>(result);
        return userResponse;
    }

    public async Task<UserResponse> ApproveUserAsync(Guid userId)
    {
        var userDao  = await  _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Id == userId);

        if (userDao == null)
        {
            throw new BadHttpRequestException("Credentials are Wrong", 500);
        }
        
        userDao.IsVertified = Constants.VerificationStatus[Constants.Verified];
        _context.Users.Update(userDao);
        var saveChangesAsync = await _context.SaveChangesAsync();
        return _mapper.Map<UserResponse>(userDao);

    }

    public async Task<UserResponse> UpdateUserAsync(Guid id, UserUpdateRequest request)
    {
        var exists = await _context.Users.AsNoTracking().
            FirstOrDefaultAsync(user => user.Id == id);
        if (exists == null)
        {
            return null;
        }

        var userDao = _mapper.Map<UserDao>(request);
        userDao.Password = exists.Password;
        userDao.Iv = exists.Iv;
        userDao.Key = exists.Key;
        _context.Users.Update(userDao);
        var saveAsyncChange =await _context.SaveChangesAsync();
        if (saveAsyncChange > 0)
        {
            var userById = await _context.Users.AsNoTracking().
                FirstOrDefaultAsync(org => org.Id == id);
            return _mapper.Map<UserResponse>(userById);
        }

        return null;
    }

    public async Task<UserResponse> RegisterScanner(CreatUserAdminRequest createScanner)
    {
        var userExist = await GetUserByNationIdAsync(createScanner.NationalId);

        if (userExist != null)
        {
            throw new BadHttpRequestException(CommonExceptions.NationalIdAlreadyRegistered.Message, 400);
        }

        var userDao = _mapper.Map<UserDao>(createScanner);
        var (encryptedPassword, key, iv) = _cryptoService.Encrypt(createScanner.Password);
        userDao.Password = encryptedPassword;
        userDao.Key = key;
        userDao.Iv = iv;
        userDao.UserType = createScanner.UserType;

        var entityEntry = await _context.Users.AddAsync(userDao);
        var saveAsync = await _context.SaveChangesAsync();

        var userResponse = _mapper.Map<UserResponse>(userDao);
        return userResponse;
    }

    public async Task<UserResponse> DeleteUserASync(Guid id)
    {
        var exists = await _context.Users.AsNoTracking().FirstOrDefaultAsync(user=>user.Id == id);
        if (exists == null)
        {
            return null;
        }

        var deleteUser =_context.Users.Remove(exists);
        var save =await _context.SaveChangesAsync();
        var response = _mapper.Map<UserResponse>(exists);
        return response;
    }


    private async Task<UserDao?> GetUserDaoByIdAsync(Guid userId)
    {
        var user  = await  _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Id == userId);
        return user;
    }

    public async Task<UserDao?> GetUserByNationIdAsync(string nationalId)
    {
       var firstOrDefaultAsync = await _context.Users.AsNoTracking().Where(user => user.NationalId == nationalId)
            .FirstOrDefaultAsync();

 
       return firstOrDefaultAsync;
    }
}