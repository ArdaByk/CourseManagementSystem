using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.EntityConfigurations;

public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("Attendances").HasKey(a => a.Id);
        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.StudentId).HasColumnName("StudentId").IsRequired();
        builder.Property(a => a.CourseId).HasColumnName("CourseId").IsRequired();
        builder.Property(a => a.CourseGroupId).HasColumnName("CourseGroupId").IsRequired();
        builder.Property(a => a.Date).HasColumnName("Date").IsRequired();
        builder.Property(a => a.Status).HasColumnName("Status").IsRequired();
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        builder
            .HasOne(a => a.Student)
            .WithMany(s => s.Attendances)
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(a => a.Course)
            .WithMany(c => c.Attendances)
            .HasForeignKey(a => a.CourseId);

        builder
            .HasOne(a => a.CourseGroup)
            .WithMany(cg => cg.Attendances)
            .HasForeignKey(a => a.CourseGroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
