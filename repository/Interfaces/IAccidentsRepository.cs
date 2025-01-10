using models.Entities;

namespace repository.Interfaces
{
    public interface IAccidentsRepository
    {
        Task<Accident?> CreateAccident(Accident accident);
        Task<Service?> CreateService(Service service);
        Task<Accident?> GetAccidentById(int id);
        Task<List<Accident>> GetAccidents();
        Task<Service?> GetServiceById(int id);
        Task<List<Service>> GetServices();
    }
}
