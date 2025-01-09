using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using models.Entities;

namespace data_access.EntityConfigs
{
    public class VehicleModelEntityConfig : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.Name)
                .IsRequired(false)
                .HasColumnType("nvarchar(100)");

            builder.HasData(
                new VehicleModel() { Id = 1, Name = "Camry" },
                new VehicleModel() { Id = 2, Name = "Corolla" }
            );
        }
    }
}
