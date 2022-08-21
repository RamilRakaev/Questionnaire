using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Questionnaire.Blazor.Data;
using Questionnaire.Blazor.Models.Questions.Tags;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure;
using Questionnaire.Infrastructure.Commands.Handlers.UniversalHandlers;
using Questionnaire.Infrastructure.Commands.Requests.UniversalCommands;
using Questionnaire.Infrastructure.Database;
using AutoMapper;
using Questionnaire.Infrastructure.Queries.Requests.UniversalQueries;
using Questionnaire.Infrastructure.Queries.Handlers.UniversalHandlers;

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
            services.AddSingleton<WeatherForecastService>();

            services.AddDbContext<Context>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultDbConnection"),
                o => o.MigrationsAssembly(typeof(Context).Assembly.FullName)));

            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddMediatR(CQRSAssemblyInfo.Assembly);

            services.AddMapper();
            services.ConfigureEntitiesQueryHandlers<BaseEntity>(typeof(GetEntitiesQuery<>), typeof(GetEntitiesHandler<>));
            services.ConfigureEntityQueryHandlers<BaseEntity>(typeof(GetEntityQuery<>), typeof(GetEntityHandler<>));

            services.AddTransient<IRequestHandler<CreateOrChangeEntityCommand<AnswerEntity>, Unit>, CreateOrChangeEntityHandler<AnswerEntity>>();
            
            services.ConfigureEntityCommandHandlers<BaseEntity>(typeof(CreateOrChangeEntityCommand<>), typeof(CreateOrChangeEntityHandler<>));
            services.ConfigureEntityCommandHandlers<BaseEntity>(typeof(RemoveEntityCommand<>), typeof(RemoveEntityHandler<>));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
