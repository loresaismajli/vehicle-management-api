using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using models.Entities;

namespace data_access.EntityConfigs
{
    public class VehicleReportEntityConfig : IEntityTypeConfiguration<VehicleReport>
    {
        public void Configure(EntityTypeBuilder<VehicleReport> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.Description)
                .IsRequired(false)
                .HasColumnType("nvarchar(500)");

            builder.Property(e => e.VehicleId)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(e => e.Date)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder
                .HasOne(e => e.Vehicle)
                .WithMany(v => v.VehicleReports)
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new VehicleReport() { Id = 1, Description = "Vehicle inspection report", VehicleId = 1, Date = DateTime.Now }
            );
        }
    }

}
