using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAOLibrary.User;
using Microsoft.AspNetCore.Mvc;


namespace DAOLibrary.Pass;

public class UserPassDao
{
    public Guid Id { get; set; }
    
    public  Guid UserId { get; set; }
    
    public UserDao User { get; set; }
    
    public Guid PassId { get; set; }
    
    public virtual PassDao Pass { get; set; }
    
}