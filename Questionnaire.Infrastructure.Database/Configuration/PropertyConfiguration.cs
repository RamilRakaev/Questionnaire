using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Database.Configuration
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder
                .HasOne(property => property.Structure)
                .WithMany(structure => structure.Properties)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(property => property.StructureId);

            builder
                .HasOne(property => property.CustomType)
                .WithMany(structure => structure.CustomProperties)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(property => property.CustomTypeId);
        }
    }
}
