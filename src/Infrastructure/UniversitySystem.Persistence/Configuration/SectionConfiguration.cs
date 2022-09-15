using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Persistence.Configuration
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasIndex(s => s.Name).IsUnique();
            builder.HasIndex(s => s.Code).IsUnique();
            builder.Property(s => s.Name).HasMaxLength(100);
            builder.Property(s => s.Code).HasMaxLength(15);
        }
    }
}
