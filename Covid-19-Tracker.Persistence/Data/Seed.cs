using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Covid_19_Tracker.Persistence.Data
{
    public static class Seed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
           
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { "Admin", "Manager", "User" };
            IdentityResult roleResult;
            foreach (var role in roles)
            {
                var roleExist = await RoleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var admin = new IdentityUser
            {
                UserName = Configuration.GetSection("AdminCredentials")["UserName"]
            };

            string userPassword = Configuration.GetSection("AdminCredentials")["UserPassword"];
            var user = await UserManager.FindByNameAsync(Configuration.GetSection("AdminCredentials")["UserName"]);

            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(admin, userPassword);
                if (createPowerUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
