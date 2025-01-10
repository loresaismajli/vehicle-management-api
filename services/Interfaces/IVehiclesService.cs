using models.Entities;

namespace services.Interfaces
{
    public interface IVehiclesService
    {
        Task<Vehicle> CreateVehicle(Vehicle vehicle);
        Task<Vehicle> GetVehicleById(int id);
        Task<List<Vehicle>> GetVehicles();
    }
}
