using DTOLibrary.UserDto;

namespace DTOLibrary.PassLogDto;

public class PassLogResponse
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    
    public Guid ScannerId { get; set; }
    public UserResponse Scanner { get; set; }
}