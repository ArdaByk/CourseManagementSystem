using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.EntityConfigurations;

public class LogConfiguration : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.ToTable("Logs").HasKey(l => l.Id);

        builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
        builder.Property(l => l.Level).HasColumnName("Level").IsRequired().HasMaxLength(20);
        builder.Property(l => l.RequestName).HasColumnName("RequestName").IsRequired().HasMaxLength(200);
        builder.Property(l => l.Message).HasColumnName("Message").IsRequired().HasMaxLength(1000);
        builder.Property(l => l.UserId).HasColumnName("UserId").HasMaxLength(100);
        builder.Property(l => l.Username).HasColumnName("Username").HasMaxLength(150);
        builder.Property(l => l.Payload).HasColumnName("Payload");
        builder.Property(l => l.ElapsedMilliseconds).HasColumnName("ElapsedMilliseconds");
        builder.Property(l => l.ExceptionMessage).HasColumnName("ExceptionMessage");
        builder.Property(l => l.ExceptionStackTrace).HasColumnName("ExceptionStackTrace");

        builder.Property(l => l.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(l => l.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(l => l.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(l => l.CreatedDate);
        builder.HasIndex(l => l.Level);
        builder.HasIndex(l => l.RequestName);
    }
}


