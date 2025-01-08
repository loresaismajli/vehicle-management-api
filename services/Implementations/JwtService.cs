using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using models.Entities;
using models.Utils;
using services.Interfaces;

namespace services.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            JwtSecurityToken token = CreateJwtSecurityToken(user);
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

        private JwtSecurityToken CreateJwtSecurityToken(User user)
        {
            string issuer = _configuration[AppSettingsKeys.JWT_ISSUER_KEY];
            string audience = _configuration[AppSettingsKeys.JWT_AUDIENCE_KEY];
            var credentials = CreateSigningCredentials();
            var claims = CreateClaims(user);

            return new JwtSecurityToken(
              issuer,
              audience,
              claims: claims,
              expires: DateTime.Today.AddHours(25),
              signingCredentials: credentials
            );
        }

        private SigningCredentials CreateSigningCredentials()
        {
            string secretKey = _configuration[AppSettingsKeys.JWT_SECRET_KEY];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            return credentials;
        }

        private Claim[] CreateClaims(User user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim("userId", user.Id.ToString(), ClaimValueTypes.Integer));
            claims.Add(new Claim("email", user.Email, ClaimValueTypes.String));
            claims.Add(new Claim("firstName", user.FirstName, ClaimValueTypes.String));
            claims.Add(new Claim("lastName", user.LastName, ClaimValueTypes.String));
            claims.Add(new Claim("roleId", user.Role.Id.ToString(), ClaimValueTypes.Integer));
            claims.Add(new Claim("role", user.Role.Name, ClaimValueTypes.String));
            claims.Add(new Claim(ClaimTypes.Role, user.Role.Name, ClaimValueTypes.String));

            return claims.ToArray();

        }
    }
}
