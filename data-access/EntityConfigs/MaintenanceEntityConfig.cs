using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using models.Entities;

namespace data_access.EntityConfigs
{
    public class MaintenanceEntityConfig : IEntityTypeConfiguration<Maintenance>
    {
        public void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.Name)
                .IsRequired(false)
                .HasColumnType("nvarchar(100)");

            builder.HasData(
                new Maintenance() { Id = 1, Name = "Oil Change" }
            );
        }
    }

}
