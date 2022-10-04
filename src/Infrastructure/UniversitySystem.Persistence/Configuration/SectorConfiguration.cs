using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Persistence.Configuration
{
    public class SectorConfiguration : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.HasIndex(s => s.Name).IsUnique();
            builder.Property(s => s.Name).HasMaxLength(20);
        }
    }
}
