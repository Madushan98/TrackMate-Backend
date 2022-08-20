

using DAOLibrary.User;

namespace DAOLibrary.Pass;

public class PassLogDao
{
    public Guid Id { get; set; }
    
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    
    public Guid ScannerId { get; set; }
    public virtual UserDao Scanner { get; set; }

    public Guid PassId { get; set; }
    public virtual PassDao Pass { get; set; }
    
    public Guid UserId { get; set; }
    public virtual UserDao User { get; set; }
}