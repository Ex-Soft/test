using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> Get([FromQuery] string statusCode)
        {
            if (!string.IsNullOrWhiteSpace(statusCode) && int.TryParse(statusCode, out var newStatusCode))
            {
                return new ObjectResult(new { errorMessage = "ErrorMessage" }) {StatusCode = newStatusCode};
            }

            await Task.Delay(5000);

            return new ObjectResult(GetItemDtos());
        }

        private static IEnumerable<ItemDto> GetItemDtos()
        {
            return Enumerable.Range(0, 10).Select(x => new ItemDto {Id = x, Name = $"Item #{x}"});
        }
    }
}
