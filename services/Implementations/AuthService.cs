using exceptions;
using models.DTOs;
using models.Entities;
using services.Interfaces;

namespace services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IJwtService _jwtService;

        public AuthService(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public async Task<string> Login(Login login)
        {
            User? user = new User()
            {
                Id = 1,
                Email = "test@test.com",
                FirstName = "Testim",
                LastName = "Testeri",
                PhoneNumber = "1234567890",
                RoleId = 1,
                Role = new Role()
                {
                    Id = 1,
                    Name = "Administrator",
                }
            };

            if (user == null) throw new UserNotFoundException();

            bool validPassword = ValidateCredentials(login.Email, login.Password);

            if (!validPassword) throw new InvalidCredentialsException();

            string jwtToken = _jwtService.GenerateToken(user);

            return jwtToken;
        }

        private bool ValidateCredentials(string email, string password)
        {
            return true;
        }
    }
}
