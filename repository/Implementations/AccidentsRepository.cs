using data_access;
using exceptions;
using Microsoft.EntityFrameworkCore;
using models.Entities;
using repository.Interfaces;

namespace repository.Implementations
{
    public class AccidentsRepository : IAccidentsRepository
    {
        private readonly ApplicationDbContext _context;

        public AccidentsRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Accident?> CreateAccident(Accident accident)
        {
            try
            {
                await _context.Accidents.AddAsync(accident);
                await _context.SaveChangesAsync();
                return accident;
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex);
            }
        }

        public async Task<Service?> CreateService(Service service)
        {
            try
            {
                await _context.Services.AddAsync(service);
                await _context.SaveChangesAsync();
                return service;
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex);
            }
        }

        public async Task<Accident?> GetAccidentById(int id)
        {
            return await _context.Accidents
                .Include(x => x.User)
                .Include(x => x.Vehicle)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Accident>> GetAccidents()
        {
            return await _context.Accidents.ToListAsync();
        }

        public async Task<Service?> GetServiceById(int id)
        {
            return await _context.Services
                .Include(x => x.User)
                .Include(x => x.Vehicle)
                .Include(x => x.ServiceType)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Service>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }
    }
}
