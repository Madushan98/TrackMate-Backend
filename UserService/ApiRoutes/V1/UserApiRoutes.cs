namespace UserService.ApiRoutes.V1;

public class UserApiRoutes
{
    public const string Root = "api";
    public const string Version = "v1";
    public const string Base = Root + "/" + Version;

    public static class User
    {
        public const string GetUserDetails = Base + "/user/" + UserId;
        public const string GetVaccinationDetails = Base + "/user/vaccination-details/" + UserId ;
        public const string UpdateVaccinationDetails = Base + "/user/vaccination-details"  ;
        public const string UpdateUserOrganization = Base + "/user/update-organization"  ;
        public const string UserId = "{userId:Guid}";
    }
    
  
}