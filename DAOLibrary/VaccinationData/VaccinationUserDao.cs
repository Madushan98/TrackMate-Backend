using DAOLibrary.User;
using DAOLibrary.VaccinationData;

namespace DAOLibrary.VacinationData;

public class VaccinationUserDao
{
    public Guid Id { get; set; }
    
    public  Guid UserId { get; set; }
    
    public UserDao User { get; set; }
    
    public Guid VaccinationDataId { get; set; }
    
    public VaccinationDataDao VaccinationData { get; set; }
}