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
            },
            new OrganizationDao()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                OrganizationName = "Test1 Organization",
                OrganizationType = "School",
                IsApproved = true,
                EmployeesWithPasses = 0,
            },
            new OrganizationDao()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                OrganizationName = "Test2 Organization",
                OrganizationType = "University",
                IsApproved = false,
                EmployeesWithPasses = 0,
            },
            new OrganizationDao()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                OrganizationName = "Test3 Organization",
                OrganizationType = "Garment",
                IsApproved = true,
                EmployeesWithPasses = 0,
            }
        };
    }
}