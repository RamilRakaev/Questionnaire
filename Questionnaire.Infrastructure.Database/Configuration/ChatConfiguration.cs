using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Database.Configuration
{
    public class ChatConfiguration : IEntityTypeConfiguration<QrlkChat>
    {
        public void Configure(EntityTypeBuilder<QrlkChat> builder)
        {
            builder
                .HasOne(chat => chat.User)
                .WithMany(user => user.QrlkChats)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(chat => chat.UserId);
        }
    }
}
