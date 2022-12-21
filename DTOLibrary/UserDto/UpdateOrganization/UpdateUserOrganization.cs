namespace DTOLibrary.UserDto.AddOrganization;

public class UpdateUserOrganizationRequest
{
    public Guid UserId { get; set; }
    public Guid OrganizationId { get; set; }
    
    public int EmployeeNumber { get; set; }
    
    public string? EmployeeContactNo { get; set; }

}