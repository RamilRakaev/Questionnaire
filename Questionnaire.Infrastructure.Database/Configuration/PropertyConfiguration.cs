using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Database.Configuration
{
    public class PropertyConfiguration : IEntityTypeConfiguration<PropertyEntity>
    {
        public void Configure(EntityTypeBuilder<PropertyEntity> builder)
        {
            builder
                .HasOne(property => property.Questionnaire)
                .WithMany(questionnaire => questionnaire.Properties)
                .HasForeignKey(property => property.QuestionnaireId);
        }
    }
}
