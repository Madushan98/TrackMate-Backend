using AuthService.Domain.Filters;
using DTOLibrary.Common;
using DTOLibrary.UserDto;

namespace AuthService.Services;

public interface IUserService
{
    Task<PagedResponse<UserResponse>> GetAllUsersAsync(UserFilter filter, PaginationFilter paginationFilter);
    Task<UserResponse> CreateUserAsync(UserRequest userRequest);
    // Task<UserResponse> GetUserByIdAsync(Guid userId);
    // Task<User> GetUserByUsernameAsync(string username);
    // Task<User> GetUserByEmailAsync(string email);
    // Task<bool> UpdateUserAsync(Guid userId, UserRequest userRequest);
    // Task<bool> DeleteUserAsync(Guid userId);
    // Task<bool> ChangePassword(PasswordChangeRequest request);
    // Task<PasswordResetResponse> ResetPassword(PasswordResetRequest request);
}