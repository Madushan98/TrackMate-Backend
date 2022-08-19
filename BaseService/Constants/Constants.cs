namespace BaseService.Constants;

public class Constants
{
    public static Guid AdminUserId = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public static Guid PassId = Guid.Parse("22222221-1111-1111-1111-111111111111");
    public static string AdminNationalId = "982351123V";

    public static List<string> UserTypes = new List<string>()
    {
        "Admin", "Scanner", "User"
    };

    public static int AdminUserRole = 0;
    public static int ScannerUserRole = 1;
    public static int UserUserRole = 2;

    public static List<string> PassReason = new List<string>()
    {
        "Medical", "Employee", "Other"
    };

    public static int MedicalReason = 0;
    public static int EmployeeReason = 0;
    public static int OtherReason = 0;
}