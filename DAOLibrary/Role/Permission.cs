using System.ComponentModel.DataAnnotations;
using DAOLIbrary.Role;

namespace DAOLibrary.Role;

public class Permission
{
    [Key] public int PermissionId { get; set; }
    public string Group { get; set; }
    public string Description { get; set; }

    public virtual ICollection<UserRolePermission> RolePermissions { get; set; }
}