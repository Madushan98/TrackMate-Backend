using DAOLibrary.User;
using DAOLibrary.VacinationData;

namespace DAOLibrary.VaccinationData;

public class VaccinationDataDao
{
    public Guid Id { get; set; }
    
    public String VaccineType { get; set; }
    
    public int VaccineDoseNumber { get; set; }
    
    public DateTime vaccinatedDate { get;set; } 
    
    public string vaccinatedPlace { get; set; }
    
    public VaccinationUserDao VaccinationUserDao { get; set; } 
    
}
    