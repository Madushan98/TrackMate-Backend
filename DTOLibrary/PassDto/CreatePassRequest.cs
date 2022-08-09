namespace DTOLibrary.PassDto;

public class CreatePassRequest
{
    
    public DateTime GeneratedDateTime { get; set; }

    public bool IsValid { get; set; }

    public bool IsApproved { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public Guid UserId { get; set; }
}