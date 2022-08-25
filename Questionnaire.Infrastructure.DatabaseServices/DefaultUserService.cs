using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Questionnaire.Domain.Entities.Identity;

namespace Questionnaire.Infrastructure.DatabaseServices
{
    public class DefaultUserService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        private string[] roleNames = { "admin", "interviewee" };

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
                    Email = "Admin@gmail.com",
                    UserName = "Admin@gmail.com",
                };

                await userManager.CreateAsync(user, "123AsD*@f");
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