using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Infrastructure.Database;

[assembly: HostingStartup(typeof(Questionnaire.Blazor.Areas.Identity.IdentityHostingStartup))]
namespace Questionnaire.Blazor.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Context>(options =>
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("ContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<Context>();
            });
        }
    }
}
