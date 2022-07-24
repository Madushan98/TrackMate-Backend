namespace AuthService.Contract;

public class ApiRoutes
{
    public const string Root = "api";
    public const string Version = "v1";
    public const string Base = Root + "/" + Version;

    public static class User
    {
        public const string GetAll = Base + "/User";
        public const string Create = Base + "/User";
        public const string Get = Base + "/User/" + UserId;
        public const string Update = Base + "/User/" + UserId;
        public const string Delete = Base + "/User/" + UserId;
        public const string ChangePassword = Base + "/User/changePassword";
        public const string ResetPassword = Base + "/User/resetPassword";
        public const string UserId = "{userId}";
    }
    
    public static class Auth
    {
        public const string RegisterUser = Base + "/register";
        public const string LoginUser = Base + "/login";
    }


    public static class Permission
    {
        public const string GetAll = Base + "/permission";
        public const string Create = Base + "/permission";
        public const string Get = Base + "/permission/" + PermissionId;
        public const string Update = Base + "/permission/" + PermissionId;
        public const string Delete = Base + "/permission/" + PermissionId;
        private const string PermissionId = "{permissionId}";
    }

    public static class Roles
    {
        public const string GetAll = Base + "/role";
        public const string Create = Base + "/role";
        public const string Get = Base + "/role/" + RoleId;
        public const string Update = Base + "/role/" + RoleId;
        public const string Delete = Base + "/role/" + RoleId;
        private const string RoleId = "{roleId}";
    }
}