using Microsoft.AspNetCore.Mvc;

namespace AnyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [FromHeader]
        public string Code { get; set; }

        [FromHeader]
        public string Env { get; set; }

        [FromHeader(Name = "X-Extra")]
        public string Extra { get; set; }

        [HttpGet("testheader")]
        public IActionResult TestHeader()
        {
            return Ok($"{{Code:\"{Code}\", Env:\"{Env}\", Extra:\"{Extra}\"}}");
        }
    }
}
