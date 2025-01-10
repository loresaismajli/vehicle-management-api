using exceptions;
using models.Entities;
using repository.Implementations;
using repository.Interfaces;
using services.Interfaces;

namespace services.Implementations
{
    public class VehiclesService : IVehiclesService
    {
        private readonly IVehiclesRepository _vehiclesRepository;

        public VehiclesService(IVehiclesRepository vehiclesRepository)
        {
            _vehiclesRepository = vehiclesRepository;
        }


        public async Task<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            Vehicle? result = await _vehiclesRepository.CreateVehicle(vehicle);

            if (result == null) throw new FailedToCreateException();

            return result;
        }

        public async Task<Vehicle> GetVehicleById(int id)
        {
            Vehicle? result = await _vehiclesRepository.GetVehicleById(id);

            if (result == null) throw new EntityNotFoundException();

            result.Producer.Vehicles = null;
            result.VehicleType.Vehicles = null;
            result.VehicleModel.Vehicles = null;

            return result;
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _vehiclesRepository.GetVehicles();
        }
    }
}
