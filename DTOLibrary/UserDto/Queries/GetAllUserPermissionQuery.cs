using Microsoft.AspNetCore.Mvc;

namespace AuthService.Models.Request.Queries
{
    public class GetAllUserPermissionQuery
    {
        [FromRoute(Name = "userId")] public string UserId { get; set; }
    }
}