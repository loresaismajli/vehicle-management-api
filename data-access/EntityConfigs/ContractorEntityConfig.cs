using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using models.Entities;

namespace data_access.EntityConfigs
{
    public class ContractorEntityConfig : IEntityTypeConfiguration<Contractor>
    {
        public void Configure(EntityTypeBuilder<Contractor> builder)
        {
            builder.Property(e => e.CompanyName)
                .IsRequired(false)
                .HasColumnType("nvarchar(100)");

            // Seeding Data for Contractor
            builder.HasData(
                new Contractor() { Id = 3, FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@contractor.com", Password = "password789", PhoneNumber = "1112233445", RoleId = 3, CompanyName = "ACME Corp" }
            );
        }
    }


}
