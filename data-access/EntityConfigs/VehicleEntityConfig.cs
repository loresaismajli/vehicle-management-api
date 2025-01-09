using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using models.Entities;

namespace data_access.EntityConfigs
{
    public class VehicleEntityConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.Name)
                .IsRequired(false)
                .HasColumnType("nvarchar(100)");

            builder.Property(e => e.VIN)
                .IsRequired(false)
                .HasColumnType("nvarchar(50)");

            builder.Property(e => e.ProductionYear)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.VehicleModelId)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.ProducerId)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.VehicleTypeId)
                .IsRequired(false)
                .HasColumnType("int");

            builder
                .HasOne(e => e.VehicleModel)
                .WithMany(e => e.Vehicles)
                .HasForeignKey(e => e.VehicleModelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Producer)
                .WithMany(e => e.Vehicles)
                .HasForeignKey(e => e.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.VehicleType)
                .WithMany(e => e.Vehicles)
                .HasForeignKey(e => e.VehicleTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Vehicle() { Id = 1, Name = "Toyota Camry", VIN = "1HGBH41JXMN109186", ProductionYear = 2020, VehicleModelId = 1, ProducerId = 1, VehicleTypeId = 1 }
            );
        }
    }
}
