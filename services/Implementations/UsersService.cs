using exceptions;
using models.Entities;
using repository.Interfaces;
using services.Interfaces;

namespace services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        public async Task<User> CreateUser(User user)
        {
            User? result = await _usersRepository.CreateUser(user);

            if (result == null) throw new FailedToCreateException();

            return result;
        }

        public async Task<User> GetUserById(int id)
        {
            User? result = await _usersRepository.GetUserById(id);

            if (result == null) throw new EntityNotFoundException();

            result.Role.Users = null;

            return result;
        }

        public async Task<List<User>> GetUsers()
        {
            List<Employee> employees = await _usersRepository.GetEmployees();
            List<Contractor> contractors = await _usersRepository.GetContractors();

            List<User> users = new List<User>();

            foreach (Employee employee in employees)
            {
                users.Add(employee);
            }

            foreach (Contractor contractor in contractors)
            {
                users.Add(contractor);
            }

            foreach (User user in users)
            {
                user.Description = user.ToString(); // ne rast qe eshte employee ketu do te ruhet "inside user" nese eshte kontraktor ketu shkruhet "outside user"
            }

            return users;
        }
    }
}
