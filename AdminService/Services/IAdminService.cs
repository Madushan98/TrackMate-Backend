using AuthService.Domain.Filters;
using DTOLibrary.Common;
using DTOLibrary.UserDto;

namespace AdminService.Services;

public interface IUserService
{
    Task<PagedResponse<UserResponse>> GetAllUsersAsync(UserFilter filter, PaginationFilter paginationFilter);
    Task<UserResponse> CreateUserAsync(CreateUserRequest createUserRequest);
    Task<UserResponse> GetUserByIdAsync(Guid userId);
    Task<UserResponse> ApproveUserAsync(Guid userId);
}