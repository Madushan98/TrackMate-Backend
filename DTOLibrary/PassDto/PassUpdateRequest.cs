namespace DTOLibrary.PassDto;

public class PassUpdateRequest
{
    public Guid Id { get; set; }

    public DateTime GeneratedDateTime { get; set; }

    public bool IsValid { get; set; }

    public bool IsApproved { get; set; }
    
    public bool IsReoccurring { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }
    
    public Guid ApprovedUserId { get; set; }
}