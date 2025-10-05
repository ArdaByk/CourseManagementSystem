using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.EntityConfigurations;

public class ExamResultConfiguration : IEntityTypeConfiguration<ExamResult>
{
    public void Configure(EntityTypeBuilder<ExamResult> builder)
    {
        builder.ToTable("ExamResults").HasKey(er => er.Id);
        builder.Property(er => er.Id).HasColumnName("Id").IsRequired();
        builder.Property(er => er.Score).HasColumnName("Score").IsRequired();
        builder.Property(er => er.Grade).HasColumnName("Grade").IsRequired();
        builder.Property(er => er.ExamId).HasColumnName("ExamId").IsRequired();
        builder.Property(er => er.StudentId).HasColumnName("StudentId").IsRequired();
        builder.Property(er => er.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(er => er.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(er => er.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(er => !er.DeletedDate.HasValue);

        builder
           .HasOne(er => er.Exam)
           .WithMany(e => e.ExamResults)
           .HasForeignKey(a => a.ExamId)
           .OnDelete(DeleteBehavior.Cascade);
       
        builder
           .HasOne(er => er.Student)
           .WithMany(s => s.ExamResults)
           .HasForeignKey(er => er.StudentId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}
