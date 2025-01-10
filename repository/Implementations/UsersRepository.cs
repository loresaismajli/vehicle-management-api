using data_access;
using exceptions;
using Microsoft.EntityFrameworkCore;
using models.Entities;
using repository.Interfaces;

namespace repository.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;

        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<User?> CreateUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex);
            }
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<Contractor>> GetContractors()
        {
            return await _context.Contractors.ToListAsync();
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
