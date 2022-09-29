using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Persistence.Configuration
{
    public class PointListConfiguration : IEntityTypeConfiguration<PointList>
    {
        public void Configure(EntityTypeBuilder<PointList> builder)
        {
            builder.Property(x => x.SDF1).HasMaxLength(100);
            builder.Property(x => x.SDF2).HasMaxLength(100);
            builder.Property(x => x.SDF3).HasMaxLength(100);
            builder.Property(x => x.TSI).HasMaxLength(100);
            builder.Property(x => x.SSI).HasMaxLength(100);
            builder.Property(x => x.AdditionalExam).HasMaxLength(100);
            builder.Property(x => x.ReExam).HasMaxLength(100);
        }
    }
}