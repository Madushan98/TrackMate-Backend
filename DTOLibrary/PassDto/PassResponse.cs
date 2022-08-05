using DTOLibrary.UserDto;

namespace DTOLibrary.PassDto;

public class PassResponse
{
    
    public DateTime GeneratedDateTime { get; set; }

    public bool IsValid { get; set; }

    public bool IsApproved { get; set; }
    
    public bool IsReoccurring { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }
    
    public Guid UserId { get; set; }
    public UserResponse User { get; set; }
    
    public Guid ApprovedUserId { get; set; }
    public UserResponse ApprovedUser { get; set; }
    
    public virtual ICollection<PassResponse> PassLogs { get; set; }

}