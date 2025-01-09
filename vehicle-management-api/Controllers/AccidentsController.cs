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

        [HttpGet("{id}")]
        public async Task<ResponseResult<Accident> GetAccidentById(int id)
        {
            Accident result = await _accidentsService.GetAccidentById(id);
            return ResponseResult<Accident>.Success(result);
        }
    }
}
