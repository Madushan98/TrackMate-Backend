using System.ComponentModel.DataAnnotations;
using DAOLIbrary.Role;
using DAOLIbrary.User;

namespace DAOLibrary.Role;

public class UserRoleUser
{
    [Key] public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid UserRoleId { get; set; }

    public User User { get; set; }
    public UserRole UserRole { get; set; }
}