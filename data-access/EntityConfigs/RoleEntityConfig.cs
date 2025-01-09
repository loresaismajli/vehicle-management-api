using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using models.Entities;

namespace data_access.EntityConfigs
{
    public class RoleEntityConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.Name)
                .IsRequired(false)
                .HasColumnType("nvarchar(100)");

            builder.Property(e => e.IsActive)
                .IsRequired(false)
                .HasColumnType("bit");

            builder.HasData(
                new Role() { Id = 1, Name = "Admin", IsActive = true },
                new Role() { Id = 2, Name = "User", IsActive = true }
            );
        }
    }
}
