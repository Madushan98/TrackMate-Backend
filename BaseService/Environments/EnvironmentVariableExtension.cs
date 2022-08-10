using Microsoft.Extensions.Configuration;
using System;


namespace BaseService.Environments;

public static class EnvironmentVariableExtensions
{
    public static string GetConnectionStringFromEnvironment(this IConfiguration configuration,string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            return Environment.GetEnvironmentVariable("Covid_Project_Connection_String")!;
        }
        else
        {
            return Environment.GetEnvironmentVariable(connectionString)!;
        }
        
        
    }
}