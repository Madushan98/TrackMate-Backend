namespace BaseService.Constants;

public class Constants
{
    public static Guid AdminUserId = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public static Guid PassId = Guid.Parse("22222221-1111-1111-1111-111111111111");
    public static string AdminNationalId = "982351123V";
    public static string ScannerNationalId = "988888188";
    public static string UserNationalId = "988888888"; 
    
    public static Guid OrganizationId = Guid.Parse("11111111-1111-1111-1111-111111111111");

    
    public static List<string> UserTypes = new List<string>()
    {
        "Admin", "Scanner", "User","Organization"
    };

    public static int AdminUserRole = 0;
    public static int ScannerUserRole = 1;
    public static int UserUserRole = 2; 
    public static int UserOrganizationRole = 3;


    
    public static List<string> PassCategory = new List<string>()
    {
       "Emergency", "Medical", "Employee", "Other"
    };

    public static int EmergencyReason = 0;
    public static int MedicalReason = 1;
    public static int EmployeeReason = 2;
    public static int OtherReason = 3;
    
    public static List<string> VerificationStatus = new List<string>()
    {
        "Verified", "Not Verified", "Pending",
    };

    public static int Verified = 0;
    public static int NotVerified = 1;
    public static int Pending = 2;

    public static List<string> OrganizationTypes = new List<string>()
    {
        "Banks", "Hospital", "School", "Other"
    };
}