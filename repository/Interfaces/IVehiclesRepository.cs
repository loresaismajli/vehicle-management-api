using models.Entities;

namespace repository.Interfaces
{
    public interface IVehiclesRepository
    {
        Task<Vehicle?> CreateVehicle(Vehicle vehicle);
        Task<Vehicle?> GetVehicleById(int id);
        Task<List<Vehicle>> GetVehicles();
    }
}
