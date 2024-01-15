using Microsoft.EntityFrameworkCore;
using PocketA3.Features.Auth.Model;

namespace PocketA3.Features.Auth
{
    public class AuthApiContext : DbContext
    {
        public AuthApiContext(DbContextOptions<AuthApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<RegisteringUser> RegisteringUser { get; set; }
    }
}
