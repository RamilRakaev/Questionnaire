using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Questionnaire.Blazor.Areas.Identity;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Entities.Identity;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure;
using Questionnaire.Infrastructure.Commands.Handlers.UniversalHandlers;
using Questionnaire.Infrastructure.Commands.Requests.UniversalCommands;
using Questionnaire.Infrastructure.Database;
using Questionnaire.Infrastructure.DatabaseServices;
using Questionnaire.Infrastructure.Queries.Handlers.UniversalHandlers;
using Questionnaire.Infrastructure.Queries.Requests.UniversalQueries;

namespace Questionnaire.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddDbContext<QuestionnaireContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ContextConnection"),
                options => options.MigrationsAssembly(typeof(QuestionnaireContext).Assembly.FullName)));
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<QuestionnaireContext>();

            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddHostedService<MigrationService>();
            services.AddHostedService<DefaultUserService>();

            services.AddScoped<TokenProvider>();

            services.AddMediatR(CQRSAssemblyInfo.Assembly);
            services.AddMapper();

            services.AddUniversalHandler<BaseEntity>(typeof(GetEntitiesQuery<>), typeof(GetEntitiesHandler<>), entityType => entityType.MakeArrayType());
            services.AddUniversalHandler<BaseEntity>(typeof(GetEntityQuery<>), typeof(GetEntityHandler<>));

            services.AddUniversalHandler<BaseEntity>(typeof(CreateOrChangeEntityCommand<>), typeof(CreateOrChangeEntityHandler<>), entityType => typeof(Unit));
            services.AddUniversalHandler<BaseEntity>(typeof(RemoveEntityCommand<>), typeof(RemoveEntityHandler<>), entityType => typeof(Unit));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
