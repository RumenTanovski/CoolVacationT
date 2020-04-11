namespace CoolVacationT.Web.SeedData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CoolVacationT.Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class ApplicationDbContextSeeder
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext dbContext;

        public ApplicationDbContextSeeder(
            IServiceProvider serviceProvider,
            ApplicationDbContext dbContext)
        {
            this.userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            this.roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            this.dbContext = dbContext;
        }

        public async Task SeedDataAsync()
        {
            await this.SeedUsersAsync();
            await this.SeedRolesAsync();
            await this.SeedUsersToRolesAsync();
        }

        private async Task SeedUsersToRolesAsync()
        {
            var user = await this.userManager.FindByNameAsync("Gosho");
            var role = await this.roleManager.FindByNameAsync("Admin");

            var exists = this.dbContext.UserRoles.Any(x => x.UserId == user.Id && x.RoleId == role.Id);

            if (exists)
            {
                return;
            }

            this.dbContext.UserRoles.Add(new IdentityUserRole<string>
            {
                RoleId = role.Id,
                UserId = user.Id,
            });

            await this.dbContext.SaveChangesAsync();
        }

        private async Task SeedRolesAsync()
        {
            var role = await this.roleManager.FindByNameAsync("Admin");

            if (role != null)
            {
                return;
            }

            await this.roleManager.CreateAsync(new IdentityRole
            {
                Name = "Admin",
            });

        }

        private async Task SeedUsersAsync()
        {
            var user = await this.userManager.FindByNameAsync("Gosho");

            if (user != null)
            {
                return;
            }

            await this.userManager.CreateAsync(
                new IdentityUser
                {
                    UserName = "Gosho",
                    Email = "gosho@abv.bg",
                    EmailConfirmed = true,
                }, "Qwerty1!");
        }
    }
}
