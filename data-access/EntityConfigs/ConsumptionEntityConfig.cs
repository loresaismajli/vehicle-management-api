using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using models.Entities;

namespace data_access.EntityConfigs
{
    public class ConsumptionEntityConfig : IEntityTypeConfiguration<Consumption>
    {
        public void Configure(EntityTypeBuilder<Consumption> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.Fuel)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.VehicleId)
                .IsRequired(false)
                .HasColumnType("int");

            builder
                .HasOne(e => e.Vehicle)
                .WithMany(e => e.Consumptions)
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Consumption() { Id = 1, Fuel = 50, VehicleId = 1 }
            );
        }
    }
}
