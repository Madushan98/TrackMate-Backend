using System.ComponentModel.DataAnnotations;
using AuthService.Domain.Filters;
using AutoMapper;
using BaseService.DataContext;
using DAOLibrary.User;
using DTOLibrary.Common;
using DTOLibrary.Exceptions;
using DTOLibrary.Helpers;
using DTOLibrary.PassDto;
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

   
   

   

    public async Task<UserResponse> GetUserByIdAsync(Guid userId)
    {
        var result = await GetUserDaoByIdAsync(userId);
        var userResponse = _mapper.Map<UserResponse>(result);
        // MapRolesAndPermissionsForResponse(userResponse, result);
        return userResponse;
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

    public async Task<UserResponse> GetUserDetailsAsync(string nationalId)
    {
        var result = await GetUserByNationIdAsync(nationalId);
        
        return   _mapper.Map<UserResponse>(result);
    }

    public async Task<UserResponse> UpdateUserAsync(string nationalId, UserUpdateRequest updateUserRequest)
    {
        var existUser = await GetUserByNationIdAsync(nationalId);
        if (existUser == null)
        {
            throw new BadHttpRequestException(CommonExceptions.UserNotFound.Message, 500); 
        }
        
        var user =  _mapper.Map<UserDao>(updateUserRequest);

        user.Id = existUser.Id;
        user.IsVertified = existUser.IsVertified;
        user.Iv = existUser.Iv;
        user.Password = existUser.Password;
        user.Key = existUser.Key;
        user.UserType = existUser.UserType;
        _context.Users.Update(user);
        var saveChangesAsync = await _context.SaveChangesAsync();
        if (saveChangesAsync < 0)
        {
            throw new BadHttpRequestException(CommonExceptions.UserNotFound.Message, 500); 
        }

        var userResponse = _mapper.Map<UserResponse>(user);

        return userResponse;

    }

    public Task<PagedResponse<PassResponse>> GetAllUsersAsync(UserFilter filter, PaginationFilter paginationFilter)
    {
        throw new NotImplementedException();
    }

   
}