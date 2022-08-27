using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Questionnaire.Domain.Entities.Identity;
using System.Security.Claims;

namespace Questionnaire.Infrastructure.DatabaseServices
{
    public class DefaultUserService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly string[] roleNames = { "admin", "questioned" };

        public DefaultUserService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
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
            if (userManager.Users.Count() == 0)
            {
                ApplicationUser user = new()
                {
                    Email = "Admin1@gmail.com",
                    UserName = "Admin1@gmail.com",
                };

                await userManager.CreateAsync(user, "Admin1@gmail.com");

                await userManager.AddToRoleAsync(user, "admin");

                Claim claim = new("role", "admin");
                await userManager.AddClaimAsync(user, claim);
            }
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
    }
}