using Microsoft.EntityFrameworkCore;
using Questionnaire.Infrastructure.Database.Configuration;

namespace Questionnaire.Infrastructure.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AnswerConfiguration());
            builder.ApplyConfiguration(new PropertyConfiguration());
            base.OnModelCreating(builder);
        }
    }
}