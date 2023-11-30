using System.Text.RegularExpressions;
using AnyTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnyTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DealersController(ILogger<DealersController> logger) : ControllerBase
    {
        private static readonly Regex IsNaN = new("\\D", RegexOptions.Compiled);
        private readonly ILogger<DealersController> _logger = logger;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Get([FromQuery] string? search)
        {
            DealerDto[] dealers =
            {
                new()
                {
                    Id = 1ul, FirstName = "1st", LastName = "Dealer", Badges = new[] {"1234567890123", "3210987654321"}
                },
                new()
                {
                    Id = 2ul, FirstName = "2nd", LastName = "Dealer", Badges = new[] { "0987654321123", "3211234567890" }

                },
            };

            var result = dealers.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(search))
                result = result.Where(Predicate);

            await Task.Delay(3000);
            return Ok(result);

            bool Predicate(DealerDto item) =>
                item.FirstName?.Contains(search, StringComparison.InvariantCultureIgnoreCase) == true ||
                item.LastName?.Contains(search, StringComparison.InvariantCultureIgnoreCase) == true ||
                (!IsNaN.IsMatch(search) && Convert.ToUInt64(search) == item.Id) ||
                item.Badges?.Contains(search, StringComparer.InvariantCultureIgnoreCase) == true;
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
