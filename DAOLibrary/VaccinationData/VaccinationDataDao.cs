using DAOLibrary.User;

namespace DAOLibrary.VaccinationData;

public class VaccinationDataDao
{
    public Guid Id { get; set; }
    
    public String VaccineType { get; set; }
    
    public int VaccineDoseNumber { get; set; }
    
    public DateTime vaccinatedDate { get;set; } 
    
    public string vaccinatedPlace { get; set; }
    
    public  Guid UserId { get; set; }
    
    public UserDao User { get; set; }
    
}
    