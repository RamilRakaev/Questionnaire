using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Database.Configuration
{
    internal class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder
                .HasOne(answer => answer.Structure)
                .WithMany(question => question.Answers)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(answer => answer.StructureId);

            builder
                .HasOne(answer => answer.User)
                .WithMany(user => user.Answers)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(answer => answer.UserId);
        }
    }
}
