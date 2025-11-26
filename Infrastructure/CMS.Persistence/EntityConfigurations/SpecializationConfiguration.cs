using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.EntityConfigurations;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.ToTable("Specializations").HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.SpecializationName).HasColumnName("SpecializationName").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

		builder.Property(s => s.SpecializationName).HasMaxLength(100);

		builder.HasIndex(s => s.SpecializationName).IsUnique();

        builder
            .HasMany(s => s.TeacherSpecializations)
            .WithOne(ts => ts.Specialization)
            .HasForeignKey(ts => ts.SpecializationId)
            .OnDelete(DeleteBehavior.Cascade);
        builder
           .HasMany(s => s.Courses)
           .WithOne(c => c.Specialization)
           .HasForeignKey(c => c.SpecializationId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
