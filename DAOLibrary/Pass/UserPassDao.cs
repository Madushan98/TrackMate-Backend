using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAOLIbrary.User;


namespace DAOLibrary.Pass;

public class UserPassDao
{
    public Guid Id { get; set; }
    
    public  Guid UserId { get; set; }
    
    public User User { get; set; }
    
    public Guid PassId { get; set; }
    
    [ForeignKey("NotificationId")] public PassDao Pass { get; set; }
    
}