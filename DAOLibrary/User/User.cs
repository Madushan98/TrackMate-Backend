namespace DAOLIbrary.User;

public class User
{
    public Guid UserId { get; set; }
    public string NationalId { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; } 
    public string? Key { get; set; }
    public string? Iv { get; set; }
    public string Password { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public DateTime JoinedDate { get; set; }
    public string? PrimaryContactNumber { get; set; }
    public string? UserType { get; set; }
    public string? Address { get; set; }
    public string? Town { get; set; }
    public string? District { get; set; }
    public bool IsVertified { get; set; }
    public string? DeviceId { get; set; }
}