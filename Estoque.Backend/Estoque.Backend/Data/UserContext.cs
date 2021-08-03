using Microsoft.EntityFrameworkCore;

namespace Estoque.Backend.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }
        public DbSet<User> UserItems { get; set; }
    }
}