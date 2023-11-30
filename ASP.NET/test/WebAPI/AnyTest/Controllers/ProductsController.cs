using System.Text.RegularExpressions;
using AnyTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnyTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(ILogger<ProductsController> logger) : ControllerBase
    {
        private static readonly Regex IsNaN = new("\\D", RegexOptions.Compiled);
        private readonly ILogger<ProductsController> _logger = logger;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Get([FromQuery] string? search)
        {
            ProductDto[] products =
            {
                new()
                {
                    Id = 1ul, Title = "Product #1", Price = 12345.45m, Sku = "3210987654321",
                    ImageUrl = "http://localhost/JavaScript/test/pix/helicopter.jpg"
                },
                new()
                {
                    Id = 2ul, Title = "Product #2", Price = 9876.90m, Sku = "1234567890123",
                    ImageUrl = "http://localhost/JavaScript/test/pix/vertriver800.jpg"
                },
            };

            var result = products.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(search))
                result = result.Where(Predicate);

            await Task.Delay(3000);
            return Ok(result);

            bool Predicate(ProductDto item) =>
                item.Title?.Contains(search, StringComparison.InvariantCultureIgnoreCase) == true ||
                (!IsNaN.IsMatch(search) && Convert.ToUInt64(search) == item.Id) ||
                item.Sku.Equals(search, StringComparison.InvariantCultureIgnoreCase);
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
