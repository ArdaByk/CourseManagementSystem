using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.EntityConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students").HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(s => s.LastName).HasColumnName("LastName").IsRequired();
		builder.Property(s => s.NationalId).HasColumnName("NationalId").IsRequired();
		builder.Property(s => s.Gender).HasColumnName("Gender").IsRequired();
        builder.Property(s => s.BirthDate).HasColumnName("BirthDate").IsRequired();
		builder.Property(s => s.Phone).HasColumnName("Phone").IsRequired();
		builder.Property(s => s.Email).HasColumnName("Email").IsRequired();
		builder.Property(s => s.Address).HasColumnName("Address").IsRequired();
        builder.Property(s => s.EmergencyContactName).HasColumnName("EmergencyContactName").IsRequired();
        builder.Property(s => s.EmergencyContactPhone).HasColumnName("EmergencyContactPhone").IsRequired();
        builder.Property(s => s.EmergencyContactRelation).HasColumnName("EmergencyContactRelation").IsRequired();
        builder.Property(s => s.Status).HasColumnName("Status").IsRequired().HasDefaultValue('A');
        builder.Property(s => s.PhotoPath).HasColumnName("PhotoPath").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

		builder.Property(s => s.FirstName).HasMaxLength(50);
		builder.Property(s => s.LastName).HasMaxLength(50);
		builder.Property(s => s.NationalId).HasMaxLength(11);
		builder.Property(s => s.Gender).HasMaxLength(1);
		builder.Property(s => s.Phone).HasMaxLength(20);
        builder.Property(s => s.Email).HasMaxLength(150);
		builder.Property(s => s.Address).HasMaxLength(300);
		builder.Property(s => s.EmergencyContactName).HasMaxLength(100);
		builder.Property(s => s.EmergencyContactPhone).HasMaxLength(20);
		builder.Property(s => s.EmergencyContactRelation).HasMaxLength(50);

        builder
		  .HasMany(s => s.Attendances)
		  .WithOne(a => a.Student)
		  .HasForeignKey(a => a.StudentId)
		  .OnDelete(DeleteBehavior.Restrict);

		builder
		 .HasMany(s => s.StudentCourses)
         .WithOne(sc => sc.Student)
         .HasForeignKey(sc => sc.StudentId)
         .OnDelete(DeleteBehavior.Restrict);
        
		builder
		 .HasMany(s => s.ExamResults)
         .WithOne(er => er.Student)
         .HasForeignKey(er => er.StudentId)
         .OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(s => s.NationalId).IsUnique();
		builder.HasIndex(s => s.Email).IsUnique();

    }
}
