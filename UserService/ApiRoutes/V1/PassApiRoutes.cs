namespace UserService.ApiRoutes.V1;

public class UserApiRoutes
{
    public const string Root = "api";
    public const string Version = "v1";
    public const string Base = Root + "/" + Version;

    public static class Pass
    {
        public const string GetAll = Base + "/Pass";
        public const string Create = Base + "/Pass";
        public const string GetToken = Base + "/Pass/GetToken";
        public const string VerifyToken = Base + "/Pass/Verify";
        public const string Get = Base + "/Pass/" + PassId;
        public const string Update = Base + "/Pass/" + PassId;
        public const string Delete = Base + "/Pass/" + PassId;
        public const string PassId = "{id:Guid}";
    }
    
    public static class PassLog
    {
        public const string GetAll = Base + "/PassLog";
        public const string Create = Base + "/PassLog";
        public const string Get = Base + "/PassLog/" + PassId;
        public const string Update = Base + "/PassLog/" + PassId;
        public const string Delete = Base + "/PassLog/" + PassId;
        public const string PassId = "{passLogId}";
    }
}