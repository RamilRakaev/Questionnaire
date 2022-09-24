using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Conventions.Identity;
using System.Security.Claims;

namespace Questionnaire.Infrastructure.DatabaseServices
{
    public class DefaultUserService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly string[] roleNames = { RoleConstants.Admin, RoleConstants.Questioned };

        public DefaultUserService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await CreateDefaultUser(userManager, roleManager);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task CreateDefaultUser(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            foreach (var roleName in roleNames)
            {
                if (await roleManager.RoleExistsAsync(roleName) == false)
                {
                    ApplicationRole role = new()
                    {
                        Name = roleName,
                    };

                    await roleManager.CreateAsync(role);
                }
            }

            await CheckDefaultUser(userManager);
        }

        private static async Task CheckDefaultUser(UserManager<ApplicationUser> userManager)
        {
            if (userManager.Users.Any() == false)
            {
                ApplicationUser user = new()
                {
                    Email = "Admin1@gmail.com",
                    UserName = "Admin1@gmail.com",
                };

                await userManager.CreateAsync(user, "Admin1@gmail.com");

                await userManager.AddToRoleAsync(user, RoleConstants.Admin);

                Claim claim = new(RoleConstants.RoleClaim, RoleConstants.Admin);
                await userManager.AddClaimAsync(user, claim);
            }
        }
    }
}