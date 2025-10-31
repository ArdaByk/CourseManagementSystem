using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography;

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

        byte[] adminSalt = new byte[] { 0x3A, 0x7F, 0x21, 0xC4, 0x55, 0x9B, 0x12, 0x88, 0xDE, 0x0A, 0x6E, 0x4C, 0x90, 0x5F, 0x33, 0xB1 };
        byte[] adminHash;
        using (var pbkdf2 = new Rfc2898DeriveBytes("123", adminSalt, 100000, HashAlgorithmName.SHA256))
        {
            adminHash = pbkdf2.GetBytes(32);
        }

        builder.HasData(
            new User
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Username = "admin",
                PasswordHash = adminHash,
                PasswordSalt = adminSalt,
                FullName = "Yönetici Kullanıcı",
                Email = "admin@cms.local",
                Phone = "+90 000 000 00 00",
                RoleId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CreatedDate = new DateTime(2025, 1, 1)
            }
        );
    }
}
