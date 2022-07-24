using AuthService.Domain.Filters;
using DTOLibrary.Common;
using DTOLibrary.UserDto;

namespace AuthService.Services;

public interface IUserService
{
    Task<PagedResponse<UserResponse>> GetAllUsersAsync(UserFilter filter, PaginationFilter paginationFilter);
    Task<UserResponse> CreateUserAsync(CreateUserRequest createUserRequest);

}