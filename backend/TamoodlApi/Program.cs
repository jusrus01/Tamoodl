using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TamoodlApi.Seeds;

namespace TamoodlApi
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILoggerFactory>()
                    .CreateLogger("app");

                try
                {
                    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    await DefaultRoles.SeedRolesAsync(userManager, roleManager);
                    await DefaultRoles.SeedStudentAsync(userManager, roleManager);
                    await DefaultRoles.SeedTeacherAsync(userManager, roleManager);
                    await DefaultRoles.SeedAdminAsync(userManager, roleManager);

                    logger.LogInformation("Success");

                }
                catch
                {
                    logger.LogWarning("An error occured seeding the database.");
                }
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
