namespace DTOLibrary.PassLogDto;

public class PassLogUpdateRequest
{
    public Guid Id { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    
    public string LogTime { get; set; }
    
    public Guid ScannerId { get; set; }
}