using DTOLibrary.UserDto;

namespace AuthService.Services;

public interface IAuthService
{
    Task<UserResponse> RegisterUserAsync(CreateUserRequest createUserRequest);
}