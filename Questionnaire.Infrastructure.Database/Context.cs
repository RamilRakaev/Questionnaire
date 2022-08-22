using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities.Identity;

namespace Questionnaire.Infrastructure.Database
{
    public class Context : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}