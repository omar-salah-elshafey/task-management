using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using UserAuthenticationApp.Models;

namespace UserAuthentication.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<TaskItem> TaskItems { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            seedRoles(builder);
            addAdmin(builder);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "f7f134cd-0c6c-46f8-80bf-dab0a7820b4c", // Admin user ID
                    RoleId = "04ac9c2b-5219-4a4f-9466-cd367d18cbf5"  // Admin role ID
                }
            );
        }

        private static void seedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin".ToUpper() },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User".ToUpper() }
                );
        }

        private static void addAdmin(ModelBuilder modelBuilder)
        {
            var adminUser = new ApplicationUser()
            {
                FirstName = "Omar",
                LastName = "Salah",
                UserName = "omar_salah",
                Email = "omarsalah@test.com",
                EmailConfirmed = true,
                NormalizedUserName = "OMAR_SALAH",
                NormalizedEmail = "omarsalah@test.com".ToUpper(),

            };
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "P@ssw0rd");
            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

        }
    }
}
