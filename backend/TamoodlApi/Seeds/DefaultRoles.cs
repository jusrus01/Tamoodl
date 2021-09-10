using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TamoodlApi.Authentication;

namespace TamoodlApi.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedRolesAsync(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Student.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Teacher.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
        }

        public static async Task SeedStudentAsync(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            var user = new IdentityUser
            {
                UserName = "student",
                Email = "student@student.com",
                EmailConfirmed = true
            };

            if(userManager.Users.All(u => u.Id != user.Id))
            {
                var createdUser = await userManager.FindByEmailAsync(user.Email);
                
                if(createdUser == null)
                {
                    await userManager.CreateAsync(user, "123Pa$$word!");
                    await userManager.AddToRoleAsync(user, Roles.Student.ToString());
                }
            }
        }

        public static async Task SeedTeacherAsync(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            var user = new IdentityUser
            {
                UserName = "teacher",
                Email = "teacher@teacher.com",
                EmailConfirmed = true
            };

            if(userManager.Users.All(u => u.Id != user.Id))
            {
                var createdUser = await userManager.FindByEmailAsync(user.Email);
                
                if(createdUser == null)
                {
                    await userManager.CreateAsync(user, "123Pa$$word!");
                    await userManager.AddToRoleAsync(user, Roles.Teacher.ToString());
                }
            }           
        }

        public static async Task SeedAdminAsync(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            var user = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@admin.com",
                EmailConfirmed = true
            };

            if(userManager.Users.All(u => u.Id != user.Id))
            {
                var createdUser = await userManager.FindByEmailAsync(user.Email);
                
                if(createdUser == null)
                {
                    await userManager.CreateAsync(user, "123Pa$$word!");
                    await userManager.AddToRoleAsync(user, Roles.Student.ToString());
                    await userManager.AddToRoleAsync(user, Roles.Teacher.ToString());
                    await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
                }
            }
        }
    }
}