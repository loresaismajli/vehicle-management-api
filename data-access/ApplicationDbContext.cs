using data_access.EntityConfigs;
using Microsoft.EntityFrameworkCore;
using models.Entities;

namespace data_access
{
    public class ApplicationDbContext : DbContext
    {
        // db sets
        public DbSet<Accident> Accidents { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleReport> VehicleReports { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }


        // constructors
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }


        // entity configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccidentEntityConfig());
            modelBuilder.ApplyConfiguration(new ConsumptionEntityConfig());
            modelBuilder.ApplyConfiguration(new ContractorEntityConfig());
            modelBuilder.ApplyConfiguration(new EmployeeEntityConfig());
            modelBuilder.ApplyConfiguration(new MaintenanceEntityConfig());
            modelBuilder.ApplyConfiguration(new ProducerEntityConfig());
            modelBuilder.ApplyConfiguration(new RegionEntityConfig());
            modelBuilder.ApplyConfiguration(new RoleEntityConfig());
            modelBuilder.ApplyConfiguration(new ServiceEntityConfig());
            modelBuilder.ApplyConfiguration(new ServiceTypeEntityConfig());
            modelBuilder.ApplyConfiguration(new UserEntityConfig());
            modelBuilder.ApplyConfiguration(new VehicleEntityConfig());
            modelBuilder.ApplyConfiguration(new VehicleModelEntityConfig());
            modelBuilder.ApplyConfiguration(new VehicleReportEntityConfig());
            modelBuilder.ApplyConfiguration(new VehicleTypeEntityConfig());
        }
    }
}
