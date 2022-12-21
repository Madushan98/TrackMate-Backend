using BaseService.Constants;
using DAOLibrary.Organization;

namespace Base.InitData.Organization;

public class OrganizationData : BaseDataInit<OrganizationDao>
{
    private const string Pass = "KcsI7gpDcpIWTwuCQUIvDA==";
    private const string Key = "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=";
    private const string Iv = "Qn0j+NTJFfCQ2Hw6WdjXqA==";
    public override List<OrganizationDao> Data()
    {
        return new List<OrganizationDao>()
        {
            new OrganizationDao()
            {
                Id = Constants.OrganizationId,
                OrganizationName = "Test Organization",
                EmailAddress = "Test@gmail.com",
                OrganizationType = "Health",
                IsApproved = true,
                EmployeesWithPasses = 0,
                MobileNumber = "07555555555",
                Password = Pass,
                Key = Key,
                Iv = Iv
            },
            new OrganizationDao()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                OrganizationName = "Test1 Organization",
                EmailAddress = "Test1@gmail.com",
                OrganizationType = "School",
                IsApproved = true,
                EmployeesWithPasses = 0,
                MobileNumber = "07666666666",
                Password = Pass,
                Key = Key,
                Iv = Iv
            },
            new OrganizationDao()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                OrganizationName = "Test2 Organization",
                EmailAddress = "Test2@gmail.com",
                OrganizationType = "University",
                IsApproved = false,
                EmployeesWithPasses = 0,
                MobileNumber = "07777777777",
                Password = Pass,
                Key = Key,
                Iv = Iv
            },
            new OrganizationDao()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                OrganizationName = "Test3 Organization",
                EmailAddress = "Test3@gmail.com",
                OrganizationType = "Garment",
                IsApproved = true,
                EmployeesWithPasses = 0,
                MobileNumber = "07612345678",
                Password = Pass,
                Key = Key,
                Iv = Iv
            }
        };
    }
}