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

        public DbSet<RegisterOTP> RegisterOTP { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisterOTP>()
                .HasOne(b => b.RegisteringUser)
                .WithMany(a => a.RegisterOTP)
                .HasForeignKey(b => b.RegistrationId);
        }
    }
}
