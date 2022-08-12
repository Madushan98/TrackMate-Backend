namespace Base;

public static class EnvConstants
{
    public static string DbConnection =
        Environment.GetEnvironmentVariable("Covid_Project_CockRoach_String")!;
}