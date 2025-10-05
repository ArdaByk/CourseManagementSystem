using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.EntityConfigurations;

public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.ToTable("StudentCourses").HasKey(sc => sc.Id);
        builder.Property(sc => sc.Id).HasColumnName("Id").IsRequired();
        builder.Property(sc => sc.RegisteredDate).HasColumnName("RegisteredDate").IsRequired();
        builder.Property(sc => sc.CompletionDate).HasColumnName("CompletionDate").IsRequired();
        builder.Property(sc => sc.StudentId).HasColumnName("StudentId").IsRequired();
        builder.Property(sc => sc.CourseId).HasColumnName("CourseId").IsRequired();
        builder.Property(sc => sc.CourseGroupId).HasColumnName("CourseGroupId").IsRequired();
        builder.Property(sc => sc.Status).HasColumnName("Status").IsRequired();
        builder.Property(sc => sc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sc => sc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sc => sc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sc => !sc.DeletedDate.HasValue);

        builder
           .HasOne(sc => sc.Student)
           .WithMany(s => s.StudentCourses)
           .HasForeignKey(sc => sc.StudentId)
           .OnDelete(DeleteBehavior.Cascade);
        
        builder
           .HasOne(sc => sc.Course)
           .WithMany(c => c.StudentCourses)
           .HasForeignKey(sc => sc.CourseId)
           .OnDelete(DeleteBehavior.Cascade);
        
        builder
           .HasOne(cs => cs.CourseGroup)
           .WithMany(cg => cg.StudentCourses)
           .HasForeignKey(sc => sc.CourseGroupId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}
