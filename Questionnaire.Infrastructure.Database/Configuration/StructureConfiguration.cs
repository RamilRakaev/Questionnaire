using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Database.Configuration
{
    public class StructureConfiguration : IEntityTypeConfiguration<Structure>
    {
        public void Configure(EntityTypeBuilder<Structure> builder)
        {
            builder
                .HasOne(structure => structure.ParentProperty)
                .WithMany(property => property.CustomTypes)
                .HasForeignKey(structure => structure.ParentPropertyId);
        }
    }
}
