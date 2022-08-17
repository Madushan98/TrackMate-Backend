
using Base.InitData.Passes;
using Base.InitData.Users;
using DAOLibrary.Pass;
using DAOLibrary.User;
using Microsoft.EntityFrameworkCore;

namespace BaseService.DataContext;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }
    
    public DbSet<UserDao> Users { get; set; }
    public DbSet<PassDao> Passes { get; set; }
    public DbSet<PassLogDao> PassLogs { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SetOnCreateData(modelBuilder);
    }
    
    private static void SetOnCreateData(ModelBuilder modelBuilder)
    {
        new UserData().Init(modelBuilder);
        new PassData().Init(modelBuilder);
    }

 
}