using Microsoft.AspNetCore.Mvc;
using models.Entities;
using services.Interfaces;
using vehicle_management_api.Helpers.Models;

namespace vehicle_management_api.Controllers
{
    [Route("api/accidents")]
    [ApiController]
    public class AccidentsController : ControllerBase
    {
        private readonly IAccidentsService _accidentsService;

        public AccidentsController(IAccidentsService accidentsService)
        {
            _accidentsService = accidentsService;
        }


        [HttpGet("")]
        public async Task<ResponseResult<List<Accident>>> GetAccidents()
        {
            List<Accident> result = await _accidentsService.GetAccidents();
            return ResponseResult<List<Accident>>.Success(result);
        }

        [HttpGet("details/{id}")]
        public async Task<ResponseResult<Accident>> GetAccidentById(int id)
        {
            Accident result = await _accidentsService.GetAccidentById(id);
            return ResponseResult<Accident>.Success(result);
        }

        [HttpPost("")]
        public async Task<ResponseResult<Accident>> CreateAccident(Accident accident)
        {
            Accident result = await _accidentsService.CreateAccident(accident);
            return ResponseResult<Accident>.Success(result);
        }

        [HttpGet("services")]
        public async Task<ResponseResult<List<Service>>> GetServices()
        {
            List<Service> result = await _accidentsService.GetServices();
            return ResponseResult<List<Service>>.Success(result);
        }

        [HttpGet("services/details/{id}")]
        public async Task<ResponseResult<Service>> GetServiceById(int id)
        {
            Service result = await _accidentsService.GetServiceById(id);
            return ResponseResult<Service>.Success(result);
        }

        [HttpPost("services")]
        public async Task<ResponseResult<Service>> CreateService(Service service)
        {
            Service result = await _accidentsService.CreateService(service);
            return ResponseResult<Service>.Success(result);
        }
    }
}
