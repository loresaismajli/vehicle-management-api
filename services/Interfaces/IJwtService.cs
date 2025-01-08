using models.Entities;

namespace services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
