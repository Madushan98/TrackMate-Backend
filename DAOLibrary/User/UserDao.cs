using System.ComponentModel.DataAnnotations;
using DAOLibrary.Pass;
using MessagePack;
using Microsoft.EntityFrameworkCore;

namespace DAOLibrary.User;

[Index(nameof(UserDao.NationalId), IsUnique=true)] 
public class UserDao
{
    public Guid Id { get; set; }
    public string NationalId { get; set; } = null!;
    public string? FullName { get; set; }
    public string? Key { get; set; }
    public string? Iv { get; set; }
    public string Password { get; set; } = null!;
    
    public DateTime BirthDate { get; set; }
    
    public DateTime JoinedDate { get; set; }
    
    public string? PrimaryContactNumber { get; set; }
    
    public string? EmergencyContactNumber { get; set; }
    
    public string? Gender { get; set; }
    
    public string? Location { get; set; }
    public string? UserType { get; set; }
    public string? Address { get; set; }
    public string? Town { get; set; }
    public string? District { get; set; }
    public bool IsVertified { get; set; }
    public string? DeviceId { get; set; }
    public  ICollection<UserPassDao>? Passes { get; set; } 
}