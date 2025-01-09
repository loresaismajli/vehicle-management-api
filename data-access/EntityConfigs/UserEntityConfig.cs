using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using models.Entities;

namespace data_access.EntityConfigs
{
    public class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.FirstName)
                .IsRequired(false)
                .HasColumnType("nvarchar(100)");

            builder.Property(e => e.LastName)
                .IsRequired(false)
                .HasColumnType("nvarchar(100)");

            builder.Property(e => e.Email)
                .IsRequired(false)
                .HasColumnType("nvarchar(100)");

            builder.Property(e => e.Password)
                .IsRequired(false)
                .HasColumnType("nvarchar(100)");

            builder.Property(e => e.PhoneNumber)
                .IsRequired(false)
                .HasColumnType("nvarchar(50)");

            builder.Property(e => e.RoleId)
                .IsRequired(false)
                .HasColumnType("int");

            builder
                .HasOne(e => e.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasDiscriminator<string>("UserType")
                .HasValue<User>("User")
                .HasValue<Contractor>("Contractor")
                .HasValue<Employee>("Employee");

            // Seeding Data
            builder.HasData(
                new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Password = "password123", PhoneNumber = "1234567890", RoleId = 1 },
                new User() { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Password = "password456", PhoneNumber = "0987654321", RoleId = 2 }
            );
        }
    }

}
