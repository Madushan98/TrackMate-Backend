namespace DTOLibrary.OrganizationDto.Login;

public class OrganizationLoginResponse
{
    public string Id { get; set; }
    
    public string UserType { get; set; }
    public string EmailAddress { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    
    public OrganizationResponse OrganizationResponse { get; set; }
}