using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.EntityConfigurations;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.ToTable("Exams").HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.ExamName).HasColumnName("ExamName").IsRequired();
        builder.Property(e => e.ExamDate).HasColumnName("ExamDate").IsRequired();
        builder.Property(e => e.MaxScore).HasColumnName("MaxScore").IsRequired();
        builder.Property(e => e.CourseId).HasColumnName("CourseId").IsRequired();
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);

        builder
         .HasOne(e => e.Course)
         .WithMany(c => c.Exams)
         .HasForeignKey(e => e.CourseId)
         .OnDelete(DeleteBehavior.Restrict);

        builder
         .HasMany(e => e.ExamResults)
         .WithOne(er => er.Exam)
         .HasForeignKey(er => er.ExamId)
         .OnDelete(DeleteBehavior.Cascade);
    }
}
