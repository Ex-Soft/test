using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet("export")]
        public IActionResult Export()
        {
            return File("""{"message":"ok"}"""u8.ToArray(), "application/json", "data.json");
        }
    }
}
