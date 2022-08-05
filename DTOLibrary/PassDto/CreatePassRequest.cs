namespace DTOLibrary.PassDto;

public class CreatePassRequest
{
    public DateTime GeneratedDateTime { get; set; }
    public Guid UserId { get; set; }
    public bool IsRecurring { get; set; }
    
}



