using AuthService.Domain.Filters;
using DAOLibrary.Organization;
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.OrganizationDto;
using DTOLibrary.OrganizationDto.Login;
using DTOLibrary.UserDto;

namespace OrganizationService.Services;

public interface IOrganizationService
{
    Task<PagedResponse<OrganizationDao>> GetAllOrganization(PaginationFilter pagination);
    Task<OrganizationDao> GetOrganizationById(Guid id);

    Task<OrganizationResponse?> UpdateOrganization(Guid id,UpdateOrganizationRequest request);
    Task<bool> DeleteById(Guid id);
    
    Task<UserResponse> GetUserByIdAsync(Guid userId);
    
    Task<PagedResponse<UserResponse>> GetAllUsersAsync(UserFilter filter, PaginationFilter paginationFilter);

}