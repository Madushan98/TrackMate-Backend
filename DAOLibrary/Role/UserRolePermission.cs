using System.ComponentModel.DataAnnotations;
using DAOLibrary.Role;


namespace DAOLibrary.Role;

public class UserRolePermission
{
    [Key] public Guid Id { get; set; }

    public Guid UserRoleId { get; set; }
    public int PermissionId { get; set; }

    public UserRole UserRole { get; set; }
    public Permission Permission { get; set; }
}