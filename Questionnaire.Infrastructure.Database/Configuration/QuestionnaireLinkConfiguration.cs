using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Database.Configuration
{
    public class QuestionnaireLinkConfiguration : IEntityTypeConfiguration<QuestionnaireLink>
    {
        public void Configure(EntityTypeBuilder<QuestionnaireLink> builder)
        {
        }
    }
}
