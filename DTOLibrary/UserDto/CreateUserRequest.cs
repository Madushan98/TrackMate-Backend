namespace DTOLibrary.UserDto;

public class CreateUserRequest
{
    public string NationalId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
    public string PrimaryContactNumber { get; set; }
    public string UserType { get; set; }
    public string Town { get; set; }
    public string District { get; set; }
    public string Address { get; set; }
    public string DeviceId { get; set; }
    public DateTime JoinedDate { get; set; }
}