namespace DTOLibrary.PassLogDto;

public class CreatePassLogRequest
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    
    public Guid ScannerId { get; set; }
    public Guid PassId { get; set; }
}