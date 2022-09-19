
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Persistence.Configuration
{
    public class PersonRegisterConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(15).IsRequired();
            builder.Property(p => p.Surname).HasMaxLength(20).IsRequired();
            builder.Property(p => p.FatherName).HasMaxLength(15).IsRequired();
        }
    }
}