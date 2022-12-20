namespace DTOLibrary.VaccinationDataDto;

public class VaccinationDataUpdateRequest
{
    public String VaccineType { get; set; }
    
    public int VaccineDoseNumber { get; set; }
    
    public DateTime vaccinatedDate { get;set; } 
    
    public string vaccinatedPlace { get; set; }
}