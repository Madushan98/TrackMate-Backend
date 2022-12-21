namespace DTOLibrary.OrganizationDto.Login;

public class OrganizationLoginResponse
{
    public string Id { get; set; }
    
    public string UserType { get; set; }
    public string EmailAddress { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    
    public string MobileNumber { get; set; }
    
    public string OrganizationType { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public string State { get; set; }
    
    public string PostalCode { get; set; }
    public OrganizationResponse OrganizationResponse { get; set; }
}