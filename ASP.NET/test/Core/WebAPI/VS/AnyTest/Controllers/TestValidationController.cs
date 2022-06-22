using System.Net;
using AnyTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestValidationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Submit([FromBody] RequestWithValidation value)
        {
            return Ok($"{{\"message\":\"{HttpStatusCode.Accepted}\"}}");
        }
    }
}
