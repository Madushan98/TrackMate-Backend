namespace BaseService.Constants;

public class Constants
{
    public static Guid AdminUserId = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public static string AdminNationalId = "982351123V";

    public static List<string> UserTypes = new List<string>()
    {
        "Admin","Scanner","User"
    };

    public static int AdminUserRole = 0;
    public static int ScannerUserRole = 1;
    public static int UserUserRole = 2;
}