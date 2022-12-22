using System.Reflection.Metadata.Ecma335;
using DAOLibrary.User;

namespace DAOLibrary.Organization;

public class OrganizationDao
{
    public Guid Id { get; set; }

    public string OrganizationName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? PostalCode { get; set; }

    public string EmailAddress { get; set; }

    public string? MobileNumber { get; set; }

    /*public string? TelNumber { get; set; }*/

    public string? Key { get; set; }

    public string? Iv { get; set; }

    public string Password { get; set; } = null!;

    public string UserType { get; set; } = "Organization";

    public string OrganizationType { get; set; }

    public bool IsApproved { get; set; }

    public int EmployeesWithPasses { get; set; }

    public ICollection<UserDao>? EmployeeList { get; set; }
}