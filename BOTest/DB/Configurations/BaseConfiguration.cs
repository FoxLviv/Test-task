using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DB.Entities;

namespace DB.Configurations
{
    class BaseConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.DateOfBirth)
                .IsRequired();

            builder.Property(e => e.Married)
                .IsRequired();

            builder.Property(e => e.Phone)
                .HasMaxLength(13)
                .IsRequired();

            builder.Property(e => e.Salary)
                .HasPrecision(16, 2)

                .IsRequired();
        }
    }
}
