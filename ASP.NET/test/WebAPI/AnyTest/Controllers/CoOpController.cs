using Microsoft.AspNetCore.Mvc;
using AnyTest.Models;

namespace AnyTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoOpController : ControllerBase
    {
        private readonly ILogger<CoOpController> _logger;

        public CoOpController(ILogger<CoOpController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(3000);
            return Ok(new CoOpDto
            {
                TotalAmount = 5320m,
                Items = new[]
                {
                    new CoOpItemDto { Date = new DateOnly(2022, 1, 1), Description = "Co-Op Deposit", ExpirationDate = new DateOnly(2023,1,1), Amount = 500m },
                    new CoOpItemDto { Date = new DateOnly(2022, 12, 1), Description = "Co-Op Deposit", ExpirationDate = DateOnly.FromDateTime(DateTime.Now), Amount = 1500m},
                    new CoOpItemDto { Date = new DateOnly(2023, 1, 1), Description = "Co-Op Deposit", ExpirationDate = new DateOnly(2023, 3,31), Amount = 5000m},
                }
            });
        }

        [HttpGet("get204")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Produces("application/json")]
        public async Task<IActionResult> Get204()
        {
            await Task.Delay(3000);
            return NoContent();
        }

        [HttpGet]
        [Route("get500")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Get500()
        {
            await Task.Delay(3000);
            return StatusCode(StatusCodes.Status500InternalServerError, "{ \"errorCode\": 500, \"errorMessage\": \"Server error\" }");
        }
    }
}