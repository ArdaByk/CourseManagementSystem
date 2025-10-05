using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.EntityConfigurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers").HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(t => t.LastName).HasColumnName("LastName").IsRequired();
		builder.Property(t => t.Phone).HasColumnName("Phone").IsRequired();
		builder.Property(t => t.Email).HasColumnName("Email").IsRequired();
		builder.Property(t => t.SalaryType).HasColumnName("SalaryType").IsRequired();
        builder.Property(t => t.SalaryAmount).HasColumnName("SalaryAmount").IsRequired();
        builder.Property(t => t.HiredDate).HasColumnName("HiredDate").IsRequired();
        builder.Property(t => t.Status).HasColumnName("Status").IsRequired();
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);

		builder.Property(t => t.FirstName).HasMaxLength(50);
		builder.Property(t => t.LastName).HasMaxLength(50);
		builder.Property(t => t.Phone).HasMaxLength(20);
		builder.Property(t => t.Email).HasMaxLength(150);
        
		builder.HasIndex(t => t.Email).IsUnique();

        builder
              .HasMany(t => t.TeacherSpecializations)
              .WithOne(ts => ts.Teacher)
              .HasForeignKey(ts => ts.TeacherId)
              .OnDelete(DeleteBehavior.Cascade);
       
        builder
              .HasMany(t => t.CourseGroups)
              .WithOne(cg => cg.Teacher)
              .HasForeignKey(cg => cg.TeacherId)
              .OnDelete(DeleteBehavior.Restrict);
    }
}
