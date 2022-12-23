using DAOLibrary.User;

namespace DAOLibrary.Pass;

public class PassLogEncryptDao
{
    public Guid Id { get; set; }
    
    public string Latitude { get; set; }
    public string Longitude { get; set; }

    public string LogTime { get; set; }
    
    public string Date { get; set; }
    public Guid ScannerId { get; set; }
    public virtual UserDao Scanner { get; set; }
    public string UserNatId { get; set; }

    public Guid PassId { get; set; }
    public virtual PassDao Pass { get; set; }
    
    public Guid UserId { get; set; }
    public virtual UserDao User { get; set; }
}