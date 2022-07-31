namespace DTOLibrary.UserDto.Login;

public class LoginResponse
{
    public string NationalId { get; set; }
    
    public string Id { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    
    public UserResponse User { get; set; }
    
}