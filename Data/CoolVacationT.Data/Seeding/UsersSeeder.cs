namespace CoolVacationT.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CoolVacationT.Common;
    using CoolVacationT.Data.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedUserAsync(userManager);
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager)
        {
            var user = await userManager.FindByNameAsync("Gosho");
            if (user == null)
            {
                var result = await userManager.CreateAsync(
                    new ApplicationUser
                {
                    UserName = "Gosho",
                    Email = "gosho@abv.bg",
                    EmailConfirmed = true,
                }, "Qwerty1!");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
