using DAOLibrary.VaccinationData;

namespace DTOLibrary.UserDto;

public class UserResponse
{
    public Guid Id { get; set; }
    public string NationalId { get; set; }
    public string? FullName { get; set; }
    public string Town { get; set; }
    public string District { get; set; }
    public bool IsVertified { get; set; }
    public string? Gender { get; set; }
    public string? Location { get; set; }
    public DateTime BirthDate { get; set; }
    public string PrimaryContactNumber { get; set; }
    public string? EmergencyContactNumber { get; set; }
    public string UserType { get; set; }
    public ICollection<int> Permissions { get; set; }
    public ICollection<string> Roles { get; set; }
    public virtual ICollection<VaccinationDataDao> VaccinationData { get; set; } 
}