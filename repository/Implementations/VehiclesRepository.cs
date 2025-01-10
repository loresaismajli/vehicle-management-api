using data_access;
using exceptions;
using Microsoft.EntityFrameworkCore;
using models.Entities;
using repository.Interfaces;

namespace repository.Implementations
{
    public class VehiclesRepository : IVehiclesRepository
    {
        private readonly ApplicationDbContext _context;

        public VehiclesRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Vehicle?> CreateVehicle(Vehicle vehicle)
        {
            try
            {
                await _context.Vehicles.AddAsync(vehicle);
                await _context.SaveChangesAsync();
                return vehicle;
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex);
            }
        }

        public async Task<Vehicle?> GetVehicleById(int id)
        {
            return await _context.Vehicles
                .Include(x => x.Producer)
                .Include(x => x.VehicleType)
                .Include(x => x.VehicleModel)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }
    }
}
