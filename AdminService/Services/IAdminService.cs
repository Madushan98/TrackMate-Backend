using AuthService.Domain.Filters;
using DTOLibrary.Common;
using DTOLibrary.UserDto;
using DTOLibrary.UserDto.AddOrganization;

namespace AdminService.Services;

public interface IUserService
{
    Task<PagedResponse<UserResponse>> GetAllUsersAsync(UserFilter filter, PaginationFilter paginationFilter);
    Task<UserResponse> CreateUserAsync(CreateUserRequest createUserRequest);
    Task<UserResponse> GetUserByIdAsync(Guid userId);
    Task<UserResponse> ApproveUserAsync(Guid userId);
    Task<UserResponse> UpdateUserAsync(Guid userId, UserUpdateRequest request);

    Task<UserResponse> RegisterScanner(CreatUserAdminRequest createScanner);
    Task<UserResponse> DeleteUserASync(Guid id);
    
}