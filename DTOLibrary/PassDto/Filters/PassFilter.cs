namespace DTOLibrary.PassDto.Filters;

public class PassFilter
{
    public Guid PassId { get; set; }
    public Guid UserId { get; set; }
    public string NationalId { get; set; }
}