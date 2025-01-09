using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using models.Entities;

namespace data_access.EntityConfigs
{
    public class VehicleTypeEntityConfig : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.Name)
                .IsRequired(false)
                .HasColumnType("nvarchar(100)");

            builder.HasData(
                new VehicleType() { Id = 1, Name = "Sedan" },
                new VehicleType() { Id = 2, Name = "SUV" }
            );
        }
    }

}
