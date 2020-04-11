namespace CoolVacationT.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CoolVacationT.Common;
    using CoolVacationT.Data.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class UsersToRolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedUsersToRolesAsync(dbContext, roleManager, userManager);
        }

        private static async Task SeedUsersToRolesAsync(
            ApplicationDbContext dbContext,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            var user = await userManager.FindByNameAsync("Gosho");
            var role = await roleManager.FindByNameAsync(GlobalConstants.AdministratorRoleName);

            var exists = dbContext.UserRoles.Any(x => x.UserId == user.Id && x.RoleId == role.Id);

            if (exists)
            {
                return;
            }

            dbContext.UserRoles.Add(new IdentityUserRole<string>
            {
                RoleId = role.Id,
                UserId = user.Id,
            });

            //if (role == null)
            //{
            //    var result = await roleManager.CreateAsync(new ApplicationRole(roleName));
            //    if (!result.Succeeded)
            //    {
            //        throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
            //    }
            //}
        }

        //var user = await this.userManager.FindByNameAsync("Gosho");
        //var role = await this.roleManager.FindByNameAsync("Admin");




    }
}
