using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.Entities;
using services.Interfaces;
using vehicle_management_api.Helpers.Models;

namespace vehicle_management_api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }


        [HttpGet("")]
        public async Task<ResponseResult<List<User>>> GetUsers()
        {
            List<User> result = await _usersService.GetUsers();
            return ResponseResult<List<User>>.Success(result);
        }

        [HttpGet("details/{id}")]
        public async Task<ResponseResult<User>> GetUserById(int id)
        {
            User result = await _usersService.GetUserById(id);
            return ResponseResult<User>.Success(result);
        }

        [HttpPost("")]
        public async Task<ResponseResult<User>> CreateUser(User user)
        {
            User result = await _usersService.CreateUser(user);
            return ResponseResult<User>.Success(result);
        }
    }
}
