using System.ComponentModel.DataAnnotations;
using AuthService.Domain.Filters;
using AutoMapper;
using BaseService.DataContext;
using DAOLIbrary.User;
using DTOLibrary.Common;
using DTOLibrary.Helpers;
using DTOLibrary.UserDto;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Services;

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

    public async Task<UserResponse> CreateUserAsync(UserRequest userRequest)
    {
        if (await GetUserByNationIdAsync(userRequest.NationalId) != null)
            throw new ValidationException("User With Same NationalCardId Already Exists");

        var user = _mapper.Map<User>(userRequest);
        // user.UserRoles = new List<UserRoleUser>();
        // var (encryptedPassword, key, iv) = _cryptoService.Encrypt(userRequest.Password);
        // user.Password = encryptedPassword;

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
        // MapRolesAndPermissionsForResponse(userResponse, result);
        return userResponse;
    }


    private async Task<User> GetUserDaoByIdAsync(Guid userId)
    {
        return await _context.Users.AsNoTracking()
            // .Include(user =>user.UserRoles )
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.UserId == userId);
    }

    public async Task<User> GetUserByNationIdAsync(string nationalId)
    {
        User firstOrDefaultAsync = null;
        Console.WriteLine("GetUserByUsernameAsync");
        try
        {
            firstOrDefaultAsync = await _context.Users.AsNoTracking().Where(user => user.NationalId == nationalId)
                .FirstOrDefaultAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine("GetUserByUsernameAsync Exception ");
            Console.WriteLine("GetUserByUsernameAsync Exception " + e.Message);
            Console.WriteLine("GetUserByUsernameAsync Exception " + e);
        }
        
        Console.WriteLine("GetUserByUsernameAsync Result " + firstOrDefaultAsync?.NationalId);
        return firstOrDefaultAsync;
    }
}