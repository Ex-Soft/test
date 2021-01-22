using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemWithEnumController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ItemWithEnumDto>> Get()
        {
            return new ObjectResult(GetItemWithEnumDtos());
        }

        private static IEnumerable<ItemWithEnumDto> GetItemWithEnumDtos()
        {
            return Enumerable.Range(0, 5).Select(x => new ItemWithEnumDto {Id = x, Value = (TestEnum)x});
        }
    }
}
