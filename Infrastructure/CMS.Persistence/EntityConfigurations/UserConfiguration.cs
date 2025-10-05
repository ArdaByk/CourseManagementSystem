using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.Username).HasColumnName("Username").IsRequired();
		builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
		builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.FullName).HasColumnName("FullName").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
        builder.Property(u => u.Phone).HasColumnName("Phone").IsRequired();
        builder.Property(u => u.RoleId).HasColumnName("RoleId").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

		builder.Property(u => u.Username).HasMaxLength(50);
		builder.Property(u => u.FullName).HasMaxLength(150);
		builder.Property(u => u.Email).HasMaxLength(150);
		builder.Property(u => u.Phone).HasMaxLength(20);

		builder.HasIndex(u => u.Username).IsUnique();
		builder.HasIndex(u => u.Email).IsUnique();

        builder
           .HasOne(u => u.Role)
           .WithMany(r => r.Users)
           .HasForeignKey(u => u.RoleId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
