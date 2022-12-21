namespace DTOLibrary.OrganizationDto;

public class UpdateOrganizationRequest
{
    public Guid Id { get; set; }
    
    public string OrganizationName { get; set; }

    public string Address { get; set; }
    
    public string City { get; set; }
    
    public string State { get; set; }
    
    public string PostalCode { get; set; }
    
    public string UserType { get; set; }
    
    public string Password { get; set; } = null!;
    
    public string EmailAddress { get; set; }

    public string MobileNumber { get; set; }
    
    public string TelNumber { get; set; }
    
    public string OrganizationType { get; set; }
    
    public int EmployeesWithPasses { get; set; }
    
    public bool IsApproved { get; set; }

}