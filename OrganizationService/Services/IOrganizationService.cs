using DAOLibrary.Organization;
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.OrganizationDto;
using DTOLibrary.OrganizationDto.Login;

namespace OrganizationService.Services;

public interface IOrganizationService
{
    Task<PagedResponse<OrganizationDao>> GetAllOrganization(PaginationFilter pagination);
    Task<OrganizationLoginResponse> CreateOrganization(CreateOrganizationRequest organizationRequest);
    Task<OrganizationDao> GetOrganizationById(Guid id);

    Task<OrganizationResponse?> UpdateOrganization(Guid id,UpdateOrganizationRequest request);
    Task<bool> DeleteById(Guid id);

}