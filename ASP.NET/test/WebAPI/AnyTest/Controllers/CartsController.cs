using System.Text.RegularExpressions;
using AnyTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnyTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class CartsController(ILogger<CartsController> logger) : ControllerBase
    {
        private static readonly Regex IsNaN = IsNanRegex();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Get([FromQuery] string? search)
        {
            CartItemDto[] cartItems =
            {
                new()
                {
                    Id = 1ul, Price = 10, Quantity = 1
                },
                new()
                {
                    Id = 2ul, Price = 20, Quantity = 1
                },
            };

            var result = cartItems.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(search))
                result = result.Where(Predicate);

            await Task.Delay(3000);
            return Ok(result);

            bool Predicate(CartItemDto item) =>
                !IsNaN.IsMatch(search) && Convert.ToUInt64(search) == item.Id;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody] CartDto? cart)
        {
            logger.LogInformation("Carts.Post()");

            if (cart?.Products == null)
            {
                return BadRequest();
            }

            await Task.Delay(3000);
            return CreatedAtAction(nameof(Get), new { search = cart.Products?[0].Id }, cart);
        }

        [HttpPost]
        [Route("post500")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Post500([FromBody] CartDto? cart)
        {
            await Task.Delay(3000);
            return StatusCode(StatusCodes.Status500InternalServerError, "{ \"errorCode\": 500, \"errorMessage\": \"Server error\" }");
        }

        [GeneratedRegex("\\D", RegexOptions.Compiled)]
        private static partial Regex IsNanRegex();
    }
}
