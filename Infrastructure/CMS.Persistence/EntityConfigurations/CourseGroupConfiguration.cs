using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.EntityConfigurations;

public class CourseGroupConfiguration : IEntityTypeConfiguration<CourseGroup>
{
    public void Configure(EntityTypeBuilder<CourseGroup> builder)
    {
        builder.ToTable("CourseGroups").HasKey(cg => cg.Id);
        builder.Property(cg => cg.Id).HasColumnName("Id").IsRequired();
        builder.Property(cg => cg.GroupName).HasColumnName("GroupName").IsRequired();
        builder.Property(cg => cg.Quota).HasColumnName("Quota").IsRequired();
        builder.Property(cg => cg.StartedDate).HasColumnName("StartedDate").IsRequired();
        builder.Property(cg => cg.EndedDate).HasColumnName("EndedDate").IsRequired();
        builder.Property(cg => cg.CourseId).HasColumnName("CourseId").IsRequired();
        builder.Property(cg => cg.ClassId).HasColumnName("ClassId").IsRequired();
        builder.Property(cg => cg.TeacherId).HasColumnName("TeacherId").IsRequired();
        builder.Property(cg => cg.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cg => cg.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cg => cg.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cg => !cg.DeletedDate.HasValue);

        builder
            .HasOne(cg => cg.Course)
            .WithMany(c => c.CourseGroups)
            .HasForeignKey(cg => cg.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(cg => cg.Class)
            .WithMany(c => c.CourseGroups)
            .HasForeignKey(cg => cg.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(cg => cg.Teacher)
            .WithMany(t => t.CourseGroups)
            .HasForeignKey(cg => cg.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);
       
        builder
            .HasMany(cg => cg.StudentCourses)
            .WithOne(sc => sc.CourseGroup)
            .HasForeignKey(sc => sc.CourseGroupId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(cg => cg.CourseSchedules)
            .WithOne(cs => cs.CourseGroup)
            .HasForeignKey(cg => cg.CourseGroupId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(cg => cg.Attendances)
            .WithOne(cs => cs.CourseGroup)
            .HasForeignKey(cg => cg.CourseGroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
