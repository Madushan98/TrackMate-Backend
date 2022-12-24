using DTOLibrary.OrganizationDto;
using DTOLibrary.OrganizationDto.Login;
using DTOLibrary.UserDto;
using DTOLibrary.UserDto.Login;

namespace AuthService.Services;

public interface IAuthService
{
    Task<LoginResponse> RegisterUserAsync(CreateUserRequest createUserRequest);
    
    Task<LoginResponse> LoginUserAsync(LoginRequest loginRequest);

    Task<OrganizationResponse> RegisterOrganization(CreateOrganizationRequest organizationRequest);
    
    Task<OrganizationLoginResponse> LoginOrganization(LoginOrganizationRequest loginOrganizationRequest);
}