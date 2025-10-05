using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.EntityConfigurations;

public class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.ToTable("Classes").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.ClassName).HasColumnName("ClassName").IsRequired();
        builder.Property(c => c.Capacity).HasColumnName("Capacity").IsRequired();
        builder.Property(c => c.Location).HasColumnName("Location").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

		builder.Property(c => c.ClassName).HasMaxLength(100);
		builder.Property(c => c.Location).HasMaxLength(100);

        builder
            .HasMany(c => c.CourseGroups)
            .WithOne(cg => cg.Class)
            .HasForeignKey(cg => cg.ClassId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}