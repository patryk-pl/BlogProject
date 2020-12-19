using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BlogProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var scope = host.Services.CreateScope();

            var ctx = scope.ServiceProvider.GetRequiredService<BlogProjectDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            ctx.Database.EnsureCreated();

            var adminRole = new IdentityRole("Admin");
            if (!ctx.Roles.Any())
            {
                roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
                //Create a role
            }

            if (!ctx.Users.Any(u => u.UserName == "admin"))
            {
                //Create an admin
                var adminUser = new IdentityUser
                {

                    UserName = "admin",
                    Email = "admin@text.com"
                };
                userManager.CreateAsync(adminUser,"password").GetAwaiter().GetResult();
                // add role to user
                userManager.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
