namespace DTOLibrary.UserDto;

public class CreateUserRequest
{
    public string NationalId { get; set; }
    public string? FullName { get; set; }
    public string Password { get; set; }
    public string? Gender { get; set; }
    public string? Location { get; set; }
    public string? Age { get; set; }
    public DateTime BirthDate { get; set; }
    public string PrimaryContactNumber { get; set; }
    public string? EmergencyContactNumber { get; set; }
    public string Town { get; set; }
    public string District { get; set; }
    public string Address { get; set; }
    public string DeviceId { get; set; }
}