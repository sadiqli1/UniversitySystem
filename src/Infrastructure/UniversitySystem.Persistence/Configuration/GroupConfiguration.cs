using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Persistence.Configuration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasIndex(g => g.Name).IsUnique();
            builder.Property(g => g.Name).HasMaxLength(5);
        }
    }
}
