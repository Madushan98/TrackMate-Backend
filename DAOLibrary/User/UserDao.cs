using System.ComponentModel.DataAnnotations;
using DAOLibrary.Organization;
using DAOLibrary.Pass;
using DAOLibrary.VacinationData;
using MessagePack;
using Microsoft.EntityFrameworkCore;

namespace DAOLibrary.User;

[Index(nameof(UserDao.NationalId), IsUnique = true)]
public class UserDao
{
    public Guid Id { get; set; }
    public string NationalId { get; set; } = null!;
    public string UserType { get; set; } = "User";
    public string? FullName { get; set; }
    public string? Key { get; set; }
    public string? Iv { get; set; }
    public string Password { get; set; } = null!;

    public string? Age { get; set; }

    public DateTime? JoinedDate { get; set; }

    public string? PrimaryContactNumber { get; set; }

    public string? EmergencyContactNumber { get; set; }

    public string? Gender { get; set; }

    public string? Location { get; set; }

    public string? Address { get; set; }
    
    public string? Town { get; set; }
    
    public string? District { get; set; }
    public bool IsVertified { get; set; }

    public string? DeviceId { get; set; }

    public ICollection<UserPassDao> Passes { get; set; }

    public ICollection<VaccinationUserDao> VaccinationUserDao { get; set; }

    public ICollection<PassDao>? EmployeeList { get; set; }

    public Guid? OrganizationDaoId { get; set; } 

    public OrganizationDao? Organization { get; set; }
}