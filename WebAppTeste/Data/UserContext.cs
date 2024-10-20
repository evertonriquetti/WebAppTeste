using Microsoft.EntityFrameworkCore;
using WebAppTeste.Models;
namespace WebAppTeste.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
