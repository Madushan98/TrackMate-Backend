namespace DTOLibrary.VaccinationDataDto;

public class VaccinationDataCreateRequest
{
    public String VaccineType { get; set; }

    public  Guid UserId { get; set; }
    
    public int VaccineDoseNumber { get; set; }
    
    public DateTime vaccinatedDate { get;set; } 
    
    public string vaccinatedPlace { get; set; }
}