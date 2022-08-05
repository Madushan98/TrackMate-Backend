using AuthService.Domain.Filters;
using DTOLibrary.Common;
using DTOLibrary.UserDto;

namespace AuthService.Services;

public interface IUserService
{
    Task<UserResponse> GetUserDetailsAsync(string NationalId);
    Task<UserResponse> UpdateUserAsync(string nationalId ,UserUpdateRequest updateUserRequest); 

}