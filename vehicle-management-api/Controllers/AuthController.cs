using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.DTOs;
using services.Interfaces;
using vehicle_management_api.Helpers.Models;

namespace vehicle_management_api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService productsService)
        {
            _authService = productsService;
        }


        [HttpPost("login")]
        public async Task<ResponseResult<string>> Login([FromBody] Login login)
        {
            string token = await _authService.Login(login);
            return ResponseResult<string>.Success(token);
        }
    }
}
