using DTOLibrary.UserDto;

namespace DTOLibrary.PassLogDto;

public class PassLogResponse
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    
    public string LogTime { get; set; }
    
    public Guid ScannerId { get; set; }
    public Guid UserId { get; set; }
    public Guid PassId { get; set; }
}