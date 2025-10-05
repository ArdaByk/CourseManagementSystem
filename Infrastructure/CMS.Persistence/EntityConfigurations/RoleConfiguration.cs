using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles").HasKey(r => r.Id);
        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.RoleName).HasColumnName("RoleName").IsRequired();
        builder.Property(r => r.Description).HasColumnName("Description").IsRequired();
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);

        builder
           .HasMany(r => r.Users)
           .WithOne(u => u.Role)
           .HasForeignKey(u => u.RoleId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
