using Landing.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Landing.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var RoleAdminId = Guid.NewGuid().ToString();
            var RoleSuperAdminId = Guid.NewGuid().ToString();
            var RoleUserId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole {Id = RoleSuperAdminId ,Name = "SuperAdmin" , NormalizedName = "SUPERADMIN" },
                 new IdentityRole { Id = RoleAdminId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = RoleUserId, Name = "User", NormalizedName = "USER" }
                );
            var hasher = new PasswordHasher<ApplicationUser>();
            var SuperAdminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "SuperAdmin@SuperAdmin.com",
                NormalizedUserName = "SUPERADMIN@SUPERADMIN.com",
                Email = "SuperAdmin@SuperAdmin.com",
                NormalizedEmail = "SUPERADMIN@SUPERADMIN.com",
                EmailConfirmed = true
            };
            SuperAdminUser.PasswordHash = hasher.HashPassword(SuperAdminUser, "Avatar@1234");
            var AdminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Admin@Admin.com",
                NormalizedUserName = "ADMIN@ADMIN.com",
                Email = "Admin@Admin.com",
                NormalizedEmail = "ADMIN@ADMIN.com",
                EmailConfirmed = true
            };
            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "Avatar@1234");

            var User = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "User@User.com",
                NormalizedUserName = "USER@USER.com",
                Email = "User@User.com",
                NormalizedEmail = "USER@USER.com",
                EmailConfirmed = true
            };
            User.PasswordHash = hasher.HashPassword(User, "Avatar@1234");


            builder.Entity<ApplicationUser>().HasData(AdminUser, SuperAdminUser, User);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = RoleSuperAdminId  , UserId = SuperAdminUser.Id },
                new IdentityUserRole<string> { RoleId = RoleAdminId, UserId = AdminUser.Id },
                new IdentityUserRole<string> { RoleId = RoleUserId, UserId = User.Id }

                );
        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
