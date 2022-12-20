namespace DTOLibrary.VaccinationDataDto;

public class VaccinationDataResponse
{
    public String VaccineType { get; set; }
    
    public int VaccineDoseNumber { get; set; }
    
    public DateTime VaccinatedDate { get;set; } 
    
    public string VaccinatedPlace { get; set; }
    
}