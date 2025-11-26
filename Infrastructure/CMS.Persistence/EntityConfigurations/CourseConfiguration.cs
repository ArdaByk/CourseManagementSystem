using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.EntityConfigurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CourseName).HasColumnName("CourseName").IsRequired();
		builder.Property(c => c.Description).HasColumnName("Description").IsRequired();
        builder.Property(c => c.DurationWeeks).HasColumnName("DurationWeeks").IsRequired();
        builder.Property(c => c.WeeklyHours).HasColumnName("WeeklyHours").IsRequired();
        builder.Property(c => c.Status).HasColumnName("Status").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

		builder.Property(c => c.CourseName).HasMaxLength(200);
		builder.Property(c => c.Description).HasMaxLength(1000);
		builder.Property(c => c.Status).HasMaxLength(1);

        builder
            .HasMany(c => c.CourseGroups)
            .WithOne(cg => cg.Course)
            .HasForeignKey(cg => cg.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(c => c.Exams)
            .WithOne(e => e.Course)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(c => c.StudentCourses)
            .WithOne(sc => sc.Course)
            .HasForeignKey(sc => sc.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(c => c.Attendances)
            .WithOne(c => c.Course)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(c => c.Specialization)
            .WithMany(s => s.Courses)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
