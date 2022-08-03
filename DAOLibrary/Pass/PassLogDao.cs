using DAOLIbrary.User;

namespace DAOLibrary.Pass;

public class PassLogDao
{
    public Guid Id { get; set; }
    
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    
    public Guid ScannerId { get; set; }
    public User Scanner { get; set; }

    public Guid PassDataId { get; set; }
    public virtual PassDao Pass { get; set; }
}