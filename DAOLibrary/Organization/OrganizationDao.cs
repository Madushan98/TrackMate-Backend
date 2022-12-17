using DAOLibrary.User;
namespace DAOLibrary.Organization;

public class OrganizationDao
{
    public Guid Id { get; set; }

    public string OrganizationName { get; set; }

    public string OrganizationType { get; set; }

    public bool IsApproved { get; set; }
    
    public int EmployeesWithPasses { get; set; }
    
    public ICollection<UserDao>? EmployeeList { get; set; }

}