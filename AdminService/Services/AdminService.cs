using System.ComponentModel.DataAnnotations;
using AuthService.Domain.Filters;
using AutoMapper;
using BaseService.DataContext;
using DAOLIbrary.User;
using DTOLibrary.Common;
using DTOLibrary.Helpers;
using DTOLibrary.UserDto;
using Microsoft.EntityFrameworkCore;

namespace AdminService.Services;

public class UserService : IUserService
{
    private readonly DBContext _context;
    private readonly IMapper _mapper;


    public UserService(DBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResponse<UserResponse>> GetAllUsersAsync(UserFilter filter,
        PaginationFilter pagination)
    {
        var queryable = _context.Users.AsNoTracking();

        queryable = AddFilterOnQuery(filter, queryable);

        var pagedResponse = await PagedResponse<User>.ToPagedList(queryable, pagination);
        return MappingHelper.MapPagination<UserResponse, User>(pagedResponse, _mapper);
    }
    


    private IQueryable<User> AddFilterOnQuery(UserFilter filter, IQueryable<User> queryable)
    {
        if (Guid.Empty != filter?.UserId)
        {
            queryable = queryable.Where(user => user.UserId == filter.UserId);
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

        var user = _mapper.Map<User>(createUserRequest);
        

        var entityEntry = await _context.Users.AddAsync(user);
        var saveChangesAsync = await _context.SaveChangesAsync();
        if (saveChangesAsync > 0)
        {
            var userByIdAsync = await GetUserByIdAsync(entityEntry.Entity.UserId);
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
            .FirstOrDefaultAsync(user => user.UserId == userId);

        if (userDao == null)
        {
            throw new BadHttpRequestException("Credentials are Wrong", 500);
        }
        
        userDao.IsVertified = true;
        _context.Users.Update(userDao);
        var saveChangesAsync = await _context.SaveChangesAsync();
        return _mapper.Map<UserResponse>(userDao);

    }

 


    private async Task<User?> GetUserDaoByIdAsync(Guid userId)
    {
        var user  = await  _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.UserId == userId);
        return user;
    }

    public async Task<User?> GetUserByNationIdAsync(string nationalId)
    {
       var firstOrDefaultAsync = await _context.Users.AsNoTracking().Where(user => user.NationalId == nationalId)
            .FirstOrDefaultAsync();

 
       return firstOrDefaultAsync;
    }
}