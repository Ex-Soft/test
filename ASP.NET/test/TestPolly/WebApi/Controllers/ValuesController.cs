using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private static readonly DateTimeOffset InitialValue = new();
        private static readonly string[] Values = {
            "value1", "value2", "value3"
        };

        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromQuery] DateTimeOffset t, [FromQuery] int n)
        {
            _logger.LogInformation($"GET t={t:o} n={n}");

            var current = DateTimeOffset.Now;
            if (n > 2 || (t != InitialValue && (current - t > TimeSpan.FromSeconds(5))))
            {
                return Values;
            }
            else
            {
                return NotFound();
            }
        }
    }
}