using DAOLibrary.Organization;
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.OrganizationDto;

namespace OrganizationService.Services;

public interface IOrganizationService
{
    Task<PagedResponse<OrganizationDao>> GetAllOrganization(PaginationFilter pagination);
    Task<OrganizationDao> CreateOrganization(OrganizationDao organizationDao);
    Task<OrganizationDao> GetOrganizationById(Guid id);
    
    Task<bool> DeleteById(Guid id);

}