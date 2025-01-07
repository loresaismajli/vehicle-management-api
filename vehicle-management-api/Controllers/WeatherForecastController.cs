using Microsoft.AspNetCore.Mvc;
using models.Entities;

namespace vehicle_management_api.Controllers
{
    [ApiController]
    [Route("home")]
    public class WeatherForecastController : ControllerBase
    {

        // home/GetText
        [HttpGet("GetText")]
        public Employee GetText()
        {

            Region region1 = new Region();
            region1.Id = 1;
            region1.Name = "DPR";

            Employee employee = new Employee();
            employee.Id = 1;
            employee.FirstName = "Test";
            employee.LastName = "Fisteku";
            employee.RegionId = 1;
            employee.Region = region1;

            return employee;
        }
    }
}
