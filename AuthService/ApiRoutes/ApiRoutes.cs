namespace AuthService.Contract;

public class ApiRoutes
{
    public const string Root = "api";
    public const string Version = "v1";
    public const string Base = Root + "/" + Version;

    public static class User
    {
     
        public const string Get = Base + "/User/" + NationalId;
        public const string Update = Base + "/User/" + NationalId;
        public const string NationalId = "{nationalId}";
    }
    
    public static class  OrganizationAuth
    {
        public const string RegisterOrganization = Base + "/Orgnization/RegisterOrgnization";
        public const string LoginOrganization = Base + "/Orgnization/LoginOrgnization";
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