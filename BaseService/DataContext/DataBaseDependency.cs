using Base;
using Microsoft.EntityFrameworkCore;
namespace BaseService.DataContext;

public class DataBaseDependency
{
    public static void Initialize(IServiceCollection services)
    {
        string connectionString = EnvConstants.DbConnection;
        
        services.AddDbContext<DBContext>(
            dbContextOptions => dbContextOptions
                .UseNpgsql(connectionString, 
                    builder =>
                        builder.MigrationsAssembly(
                            "BaseService"))
                .EnableDetailedErrors());
        
    }
}