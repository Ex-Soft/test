using Microsoft.AspNetCore.Mvc;

namespace TestNewRelicSimple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IActionResult Get([FromQuery] int statusCode)
        {
            return statusCode switch
            {
                500 => StatusCode(StatusCodes.Status500InternalServerError),
                _ => Ok(new[] { "value1", "value2" })
            };
        }
    }
}
