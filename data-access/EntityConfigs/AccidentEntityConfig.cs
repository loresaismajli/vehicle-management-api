
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using models.Entities;

namespace data_access.EntityConfigs
{
    public class AccidentEntityConfig : IEntityTypeConfiguration<Accident>
    {
        public void Configure(EntityTypeBuilder<Accident> builder)
        {
            // primary key
            builder.HasKey(e => e.Id);

            // cols
            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.Description)
                .IsRequired(true)
                .HasColumnType("nvarchar(100)");

            builder.Property(e => e.IsGuilty)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.VehicleId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.Date)
                .IsRequired()
                .HasColumnType("smalldatetime");

            builder.Property(e => e.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // relationships
            builder
                .HasOne(e => e.User)
                .WithMany(e => e.Accidents)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Vehicle)
                .WithMany(e => e.Accidents)
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            // default
            builder.Property(e => e.Date)
                .HasDefaultValueSql("GETDATE()");

            // data
            builder.HasData(
                new Accident() { Id = 1, Description = "Accident in the road", IsGuilty = false, UserId = 1, VehicleId = 1, TotalPrice = 100.00}
                );
        }
    }
}
