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
            IdentityResult _;
            foreach (var role in roles)
            {
                var roleExist = await RoleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    _ = await RoleManager.CreateAsync(new IdentityRole(role));
                }
            }

            string userName = Configuration.GetSection("AdminCredentials")["UserName"];
            var admin = new IdentityUser
            {
                UserName = userName
            };

            string userPassword = Configuration.GetSection("AdminCredentials")["UserPassword"];
            var user = await UserManager.FindByNameAsync(userName);

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
