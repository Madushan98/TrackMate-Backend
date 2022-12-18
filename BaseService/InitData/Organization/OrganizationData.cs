using BaseService.Constants;
using DAOLibrary.Organization;

namespace Base.InitData.Organization;

public class OrganizationData : BaseDataInit<OrganizationDao>
{
    public override List<OrganizationDao> Data()
    {
        return new List<OrganizationDao>()
        {
            new OrganizationDao()
            {
                Id = Constants.OrganizationId,
                OrganizationName = "Test Organization",
                OrganizationType = "Health",
                IsApproved = true,
                EmployeesWithPasses = 0,
            }
        };
    }
}