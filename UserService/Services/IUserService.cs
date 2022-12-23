using DTOLibrary.OrganizationDto;
using DTOLibrary.UserDto;
using DTOLibrary.UserDto.AddOrganization;

namespace UserService.Services;

public interface IUserService
{
    Task<UserResponse> GetUserDetailsAsync(Guid userId);

    Task<UpdateUserOrganizationResponse> UpdateUserOrganization(UpdateUserOrganizationRequest request);
    
    Task<OrganizationResponse> GetUserOrganizationAsync(Guid userId);
}