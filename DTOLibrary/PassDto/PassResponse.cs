using DTOLibrary.UserDto;

namespace DTOLibrary.PassDto;

public class PassResponse
{
    public Guid Id { get; set; }
    
    public DateTime GeneratedDateTime { get; set; }

    public bool IsValid { get; set; }

    public bool IsApproved { get; set; }

    public bool IsReoccurring { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }
    
    public Guid UserId { get; set; }
    public UserResponse User { get; set; }

    public string NationalId { get; set; }

}