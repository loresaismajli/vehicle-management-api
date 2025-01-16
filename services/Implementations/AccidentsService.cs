using exceptions;
using models.Entities;
using repository.Interfaces;
using services.Interfaces;

namespace services.Implementations
{
    public class AccidentsService : IAccidentsService
    {
        private readonly IAccidentsRepository _accidentsRepository;

        public AccidentsService(IAccidentsRepository accidentsRepository)
        {
            _accidentsRepository = accidentsRepository;
        }


        public async Task<Accident> CreateAccident(Accident accident)
        {
            Accident? result = await _accidentsRepository.CreateAccident(accident);

            if (result == null) throw new FailedToCreateException();

            return result;
        }

        public async Task<Service> CreateService(Service service)
        {
            Service? result = await _accidentsRepository.CreateService(service);

            if (result == null) throw new FailedToCreateException();

            return result;
        }

        public async Task<Accident> GetAccidentById(int id)
        {
            Accident? result = await _accidentsRepository.GetAccidentById(id);

            if (result == null) throw new EntityNotFoundException();

            result.Vehicle.Accidents = null;
            result.User.Accidents = null;

            return result;
        }

        public async Task<Service> GetServiceById(int id)
        {
            Service? result = await _accidentsRepository.GetServiceById(id);

            if (result == null) throw new EntityNotFoundException();

            result.Vehicle.Services = null;
            result.User.Services = null;
            result.ServiceType.Services = null;

            return result;
        }

        public async Task<List<Accident>> GetAccidents()
        {
            List<Accident> result = await _accidentsRepository.GetAccidents();

            return result;
        }

        public async Task<List<Service>> GetServices()
        {
            List<Service> result = await _accidentsRepository.GetServices();

            return result;
        }
    }
}
