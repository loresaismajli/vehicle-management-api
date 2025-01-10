using models.Entities;

namespace repository.Interfaces
{
    public interface IUsersRepository
    {
        Task<User?> CreateUser(User user);
        Task<User?> GetUserById(int id);
        Task<List<User>> GetUsers();
        Task<List<Employee>> GetEmployees();
        Task<List<Contractor>> GetContractors();
    }
}
