namespace PassService.ApiRoutes.V1;

public class PassApiRoutes
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
        public const string PassId = "{passId}";
    }
}