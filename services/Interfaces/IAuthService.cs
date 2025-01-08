
using models.DTOs;

namespace services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(Login login);
    }
}
