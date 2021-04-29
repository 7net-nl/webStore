using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electroShop.UI.WebUI.Areas.Users.Data
{
    public static class SeedIDentityHelper
    {
        private const string User_ID = "81fe5ab6-84ef-87fd173638fd";
        private const string Admin_ID = "81fe5ab6-84ef-87fd673638fd";
        private const string AdminRole = "Admin";
        private const string UserRole = "User";
        private const string UserEmail = "user@user.com";
        private const string AdminEmail = "admin@admin.com";
        private const string Password = "Test@123";
        private const string StampUser = "Userdfgdfgdfdfdffsdgvcxbgfhngffgc";
        private const string StampAdmin = "Admindfgdfgdfdfdffsdgvcxbgfhngffgc";
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var Hasher = new PasswordHasher<MyUser>();
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id= Admin_ID,  Name = AdminRole , NormalizedName=AdminRole.ToUpper()},
                new IdentityRole { Id=User_ID , Name =UserRole,NormalizedName=UserRole.ToUpper()}
                );

            modelBuilder.Entity<MyUser>().HasData(
                new MyUser { Id = User_ID, Email = UserEmail, NormalizedEmail = UserEmail.ToUpper(), UserName = UserEmail, NormalizedUserName = UserEmail.ToUpper(),
                    PasswordHash = Hasher.HashPassword(null, Password),SecurityStamp=StampUser },
                new MyUser { Id = Admin_ID, Email = AdminEmail, NormalizedEmail = AdminEmail.ToUpper(), UserName = AdminEmail, NormalizedUserName = AdminEmail.ToUpper(),
                PasswordHash = Hasher.HashPassword(null, Password),SecurityStamp=StampAdmin }
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = User_ID,
                    UserId = User_ID
                },
                new IdentityUserRole<string>
                {
                     RoleId = Admin_ID,
                     UserId=Admin_ID
                }

                );
        }

    }
}
