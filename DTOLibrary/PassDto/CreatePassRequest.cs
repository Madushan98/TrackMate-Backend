namespace DTOLibrary.PassDto;

public class CreatePassRequest
{
    public string NationalId { get; set; }
    public bool IsReoccurring { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    
    
}



