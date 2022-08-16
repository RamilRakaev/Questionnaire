using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Database.Configuration
{
    internal class AnswerConfiguration : IEntityTypeConfiguration<AnswerEntity>
    {
        public void Configure(EntityTypeBuilder<AnswerEntity> builder)
        {
            builder
                .HasOne(answer => answer.Questionnaire)
                .WithMany(question => question.Answers)
                .HasForeignKey(answer => answer.QuestionnaireId);

            builder
                .HasOne(answer => answer.User)
                .WithMany(user => user.Answers)
                .HasForeignKey(answer => answer.UserId);
        }
    }
}
