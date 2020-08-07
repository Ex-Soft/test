using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestHttpController : ControllerBase
    {
        private readonly ILogger<TestHttpController> _logger;

        public TestHttpController(ILogger<TestHttpController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("get1")]
        public async Task<IActionResult> Get1()
        {
            await Task.Delay(1000);
            return Ok("{\"name\":\"Get1\"}");
        }

        [HttpGet]
        [Route("get2")]
        public async Task<IActionResult> Get2()
        {
            await Task.Delay(2000);
            return Ok("{\"name\":\"Get2\"}");
        }

        [HttpGet]
        [Route("get3")]
        public async Task<IActionResult> Get3()
        {
            await Task.Delay(3000);
            return Ok("{\"name\":\"Get3\"}");
        }

        [HttpGet]
        [Route("getdtoobject1")]
        public async Task<IActionResult> GetDtoObject1()
        {
            await Task.Delay(1000);
            return Ok(new DtoObject1 {Name = "GetDtoObject1" });
        }

        [HttpGet]
        [Route("getdtoobject2")]
        public async Task<IActionResult> GetDtoObject2()
        {
            await Task.Delay(2000);
            return Ok(new DtoObject2 { Name = "GetDtoObject2" });
        }

        [HttpGet]
        [Route("getdtoobject3")]
        public async Task<IActionResult> GetDtoObject3()
        {
            await Task.Delay(3000);
            return Ok(new DtoObject3 { Name = "GetDtoObject3" });
        }

        [HttpGet]
        [Route("get200")]
        public async Task<IActionResult> Get200()
        {
            await Task.Delay(1000);
            return Ok("{ \"errorCode\": 200, \"errorMessage\": \"Ok\" }");
        }

        [HttpGet]
        [Route("get207")]
        public async Task<IActionResult> Get207()
        {
            await Task.Delay(1000);
            return StatusCode(207, "{ \"errorCode\": 207, \"errorMessage\": \"Partial Success\" }");
        }

        [HttpGet]
        [Route("get400")]
        public async Task<IActionResult> Get400()
        {
            await Task.Delay(1000);
            return BadRequest("{ \"errorCode\": 400, \"errorMessage\": \"Invalid request payload\" }");
        }

        [HttpGet]
        [Route("get409")]
        public async Task<IActionResult> Get409()
        {
            await Task.Delay(1000);
            return Conflict("{ \"errorCode\": 409, \"errorMessage\": \"Request Already Submitted\" }");
        }

        [HttpGet]
        [Route("get500")]
        public async Task<IActionResult> Get500()
        {
            await Task.Delay(1000);
            return StatusCode(StatusCodes.Status500InternalServerError, "{ \"errorCode\": 500, \"errorMessage\": \"Server error\" }");
        }
    }
}
