using DTOLibrary.UserDto.AddOrganization;

namespace UserService.Services;

public interface IUserService
{
    Task<UpdateUserOrganizationResponse> UpdateUserOrganization(UpdateUserOrganizationRequest request);
}