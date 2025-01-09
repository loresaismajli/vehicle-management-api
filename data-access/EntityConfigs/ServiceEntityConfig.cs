using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using models.Entities;

namespace data_access.EntityConfigs
{
    public class ServiceEntityConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.Number)
                .IsRequired(false)
                .HasColumnType("nvarchar(50)");

            builder.Property(e => e.Name)
                .IsRequired(false)
                .HasColumnType("nvarchar(100)");

            builder.Property(e => e.UserId)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.VehicleId)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.ServiceTypeId)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.Date)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.Property(e => e.TotalPrice)
                .IsRequired(false)
                .HasColumnType("decimal(18, 2)");

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.Services)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Vehicle)
                .WithMany(e => e.Services)
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.ServiceType)
                .WithMany(e => e.Services)
                .HasForeignKey(e => e.ServiceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Service() { Id = 1, Number = "S001", Name = "Oil Change", UserId = 1, VehicleId = 1, ServiceTypeId = 1, Date = DateTime.Now, TotalPrice = 100.00 }
            );
        }
    }
}
