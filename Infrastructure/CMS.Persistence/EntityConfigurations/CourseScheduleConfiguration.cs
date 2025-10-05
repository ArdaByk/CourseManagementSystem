using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.EntityConfigurations;

public class CourseScheduleConfiguration : IEntityTypeConfiguration<CourseSchedule>
{
    public void Configure(EntityTypeBuilder<CourseSchedule> builder)
    {
        builder.ToTable("CourseSchedules").HasKey(cs => cs.Id);
        builder.Property(cs => cs.Id).HasColumnName("Id").IsRequired();
        builder.Property(cs => cs.DayOfWeek).HasColumnName("DayOfWeek").IsRequired();
        builder.Property(cs => cs.StartTime).HasColumnName("StartTime").IsRequired();
        builder.Property(cs => cs.EndTime).HasColumnName("EndTime").IsRequired();
        builder.Property(cs => cs.CourseGroupId).HasColumnName("CourseGroupId").IsRequired();
        builder.Property(cs => cs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cs => cs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cs => cs.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cs => !cs.DeletedDate.HasValue);

        builder
         .HasOne(cs => cs.CourseGroup)
         .WithMany(cs => cs.CourseSchedules)
         .HasForeignKey(cs => cs.CourseGroupId)
         .OnDelete(DeleteBehavior.Cascade);
    }
}
