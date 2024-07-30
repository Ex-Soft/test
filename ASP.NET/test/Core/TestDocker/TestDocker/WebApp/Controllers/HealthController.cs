using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    public class HealthController(ILogger<HealthController> logger) : ControllerBase
    {
        private readonly ILogger<HealthController> _logger = logger ?? throw new ArgumentException(nameof(logger));

        [HttpGet("healthz")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Healthz()
        {
            _logger.LogInformation("healthz");
            return Ok();
        }
    }
}
