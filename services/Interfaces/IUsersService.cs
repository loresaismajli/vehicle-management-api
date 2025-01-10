using models.Entities;

namespace services.Interfaces
{
    public interface IUsersService
    {
        Task<User> CreateUser(User user);
        Task<User> GetUserById(int id);
        Task<List<User>> GetUsers();
    }
}
