using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities.Identity;

namespace Questionnaire.Infrastructure.Database
{
    public class QuestionnaireContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public QuestionnaireContext(DbContextOptions<QuestionnaireContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}