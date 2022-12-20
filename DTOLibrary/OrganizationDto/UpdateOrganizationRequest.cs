namespace DTOLibrary.OrganizationDto;

public class UpdateOrganizationRequest
{
    public Guid Id { get; set; }
    
    public string OrganizationName { get; set; }

    public string OrganizationType { get; set; }
    
    public bool IsApproved { get; set; }

}