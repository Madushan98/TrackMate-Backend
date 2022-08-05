using System.ComponentModel.DataAnnotations;
using DAOLibrary.Role;
using DAOLibrary.User;

namespace DAOLibrary.Role;

public class UserRoleUser
{
    [Key] public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid UserRoleId { get; set; }

    public UserDao User { get; set; }
    public UserRole UserRole { get; set; }
}