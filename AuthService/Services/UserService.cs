using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BaseService.DataContext;
using DAOLIbrary.User;
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

    // private void MapRolesAndPermissionsForResponse(UserResponse userResponse, User dao)
    // {
    //    // userResponse.Roles = dao.UserRoles != null ? dao.UserRoles.Select(user => user.UserRoleId.ToString()).ToList() : new List<string>();
    //
    //     var permissions = new HashSet<int>();
    //     // if (dao.UserRoles != null)
    //     // {
    //     //     foreach (var userRole in dao.UserRoles)
    //     //     {
    //     //         var list = _context.UserRolePermissions.Where(permission => permission.UserRoleId == userRole.UserRoleId).Select(permission => permission.PermissionId).ToList();
    //     //         foreach (var i in list)
    //     //         {
    //     //             permissions.Add(i);
    //     //         }
    //     //     }
    //     // }
    //
    //     userResponse.Permissions = permissions;
    // }

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