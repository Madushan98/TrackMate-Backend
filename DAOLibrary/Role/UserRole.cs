using System.ComponentModel.DataAnnotations;
using DAOLibrary.Role;

namespace DAOLibrary.Role;

public class UserRole
{
    [Key] public Guid RoleId { get; set; }

    public string RoleName { get; set; }
    public string RoleDescription { get; set; }

    public virtual ICollection<UserRolePermission> RolePermissions { get; set; }
    public virtual ICollection<UserRoleUser> RoleUsers { get; set; }
}