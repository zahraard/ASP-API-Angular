using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Users.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt): base(opt) {}
        public DbSet<User> Users { get; set; }

    }
}