using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.EntityConfigurations;

public class TeacherSpecializationConfiguration : IEntityTypeConfiguration<TeacherSpecialization>
{
    public void Configure(EntityTypeBuilder<TeacherSpecialization> builder)
    {
        builder.ToTable("TeacherSpecializations").HasKey(ts => ts.Id);
        builder.Property(ts => ts.Id).HasColumnName("Id").IsRequired();
        builder.Property(ts => ts.TeacherId).HasColumnName("TeacherId").IsRequired();
        builder.Property(ts => ts.SpecializationId).HasColumnName("SpecializationId").IsRequired();
        builder.Property(ts => ts.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ts => ts.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ts => ts.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ts => !ts.DeletedDate.HasValue);

        builder
             .HasOne(ts => ts.Teacher)
             .WithMany(t => t.TeacherSpecializations)
             .HasForeignKey(ts => ts.TeacherId)
             .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(ts => ts.Specialization)
            .WithMany(s => s.TeacherSpecializations)
            .HasForeignKey(ts => ts.SpecializationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
