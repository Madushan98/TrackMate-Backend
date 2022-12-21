namespace OrganizationService.ApiRoutes.V1;

public class OrganizationApiRoutes
{
    public const string Root = "api";
    public const string Version = "v1";
    public const string Base = Root + "/" + Version;

    public static class Organization
    {
        public const string GetAll = Base + "/Organization";
        public const string GetAllUser = GetAll + "/Users";
        public const string GetUserById = GetAll + "/User/"+OrganizationId;
        public const string RegisterAsync = Base + "/Organization";
        public const string Get = Base + "/Organization/" + OrganizationId;
        public  const  string Delete = Base + "/Organization/" + OrganizationId;
        public  const  string Update = Base + "/Organization/" + OrganizationId;
        private const string OrganizationId = "{id:Guid}";
     
    }
}