using System;
using System.Threading.Tasks;
using AuthService.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthService.DAL
{
    public class ApplicationDbContextSeeder
    {
        public static async Task SeedData(UserManager<User> userManager)
        {
            var user = await userManager.FindByEmailAsync("admin@example.com");
            if (user == null)
            {
                // Create a new user
                user = new User()
                {
                    Firstname = "Admin",
                    Lastname = "Admin",
                    UserName = "admin@example.com",
                    Email = "admin@example.com"
                };

                // Set a password for the user
                const string password = "Admin123!";
                var result = await userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create the admin user.");
                }
            }
        }

    }
}