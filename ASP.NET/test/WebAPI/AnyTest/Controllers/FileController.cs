using Microsoft.AspNetCore.Mvc;

namespace AnyTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        [HttpGet("export")]
        public IActionResult Export()
        {
            return File("""{"message":"ok"}"""u8.ToArray(), "application/json", "data.json");
        }
    }
}
