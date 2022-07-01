
using DAOLIbrary.User;
using Microsoft.EntityFrameworkCore;

namespace BaseService.DataContext;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
 
}