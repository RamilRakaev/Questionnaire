﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Database.Configuration
{
    internal class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder
                .HasOne(answer => answer.Questionnaire)
                .WithMany(question => question.Answers)
                .HasForeignKey(answer => answer.StructureId);

            builder
                .HasOne(answer => answer.User)
                .WithMany(user => user.Answers)
                .HasForeignKey(answer => answer.UserId);
        }
    }
}
