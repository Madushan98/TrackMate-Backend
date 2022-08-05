namespace DTOLibrary.UserDto;

public class UserResponse
{
    public Guid UserId { get; set; }
    public string NationalId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string PrimaryContactNumber { get; set; }
    public string Town { get; set; }
    public string District { get; set; }
    public bool IsVertified { get; set; }
    public string UserType { get; set; }
    public ICollection<int> Permissions { get; set; }
    public ICollection<string> Roles { get; set; }
}