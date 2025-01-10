using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.Entities;
using services.Interfaces;
using vehicle_management_api.Helpers.Models;

namespace vehicle_management_api.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesService _vehiclesService;

        public VehiclesController(IVehiclesService vehiclesService)
        {
            _vehiclesService = vehiclesService;
        }


        [HttpGet("")]
        public async Task<ResponseResult<List<Vehicle>>> GetVehicles()
        {
            List<Vehicle> result = await _vehiclesService.GetVehicles();
            return ResponseResult<List<Vehicle>>.Success(result);
        }

        [HttpGet("details/{id}")]
        public async Task<ResponseResult<Vehicle>> GetVehicleById(int id)
        {
            Vehicle result = await _vehiclesService.GetVehicleById(id);
            return ResponseResult<Vehicle>.Success(result);
        }

        [HttpPost("")]
        public async Task<ResponseResult<Vehicle>> CreateVehicle(Vehicle vehicle)
        {
            Vehicle result = await _vehiclesService.CreateVehicle(vehicle);
            return ResponseResult<Vehicle>.Success(result);
        }
    }
}
