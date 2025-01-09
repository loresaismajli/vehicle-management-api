using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using models.Entities;

namespace data_access.EntityConfigs
{
    public class EmployeeEntityConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.RegionId)
                .IsRequired(false)
                .HasColumnType("int");

            builder
                .HasOne(e => e.Region)
                .WithMany()
                .HasForeignKey(e => e.RegionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seeding Data for Employee
            builder.HasData(
                new Employee() { Id = 4, FirstName = "Bob", LastName = "Williams", Email = "bob.williams@company.com", Password = "password101", PhoneNumber = "5566778899", RoleId = 1, RegionId = 1 }
            );
        }
    }


}
