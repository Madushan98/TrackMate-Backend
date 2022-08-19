namespace DTOLibrary.PassDto;

public class CreatePassRequest
{
    public string NationalId { get; set; }
    public bool IsReoccurring { get; set; }
    public string PassCategory { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public Guid UserId { get; set; }

}



