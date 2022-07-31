
using Base.InitData.Users;
using DAOLIbrary.User;
using Microsoft.EntityFrameworkCore;

namespace BaseService.DataContext;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SetOnCreateData(modelBuilder);
    }
    
    private static void SetOnCreateData(ModelBuilder modelBuilder)
    {
        new UserData().Init(modelBuilder);
    }

 
}