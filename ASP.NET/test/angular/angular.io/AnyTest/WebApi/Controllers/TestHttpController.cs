using Microsoft.AspNetCore.Mvc;
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
        [Route("health")]
        [Produces("application/json")]
        public IActionResult GetGetHealth()
        {
            return Ok("{\"status\":\"ok\"}");
        }

        [HttpGet]
        [Route("get1")]
        [Produces("application/json")]
        public async Task<IActionResult> Get1()
        {
            await Task.Delay(1000);
            return Ok("{\"name\":\"Get1\"}");
        }

        [HttpGet]
        [Route("get2")]
        [Produces("application/json")]
        public async Task<IActionResult> Get2()
        {
            await Task.Delay(2000);
            return Ok("{\"name\":\"Get2\"}");
        }

        [HttpGet]
        [Route("get3")]
        [Produces("application/json")]
        public async Task<IActionResult> Get3()
        {
            await Task.Delay(3000);
            return Ok("{\"name\":\"Get3\"}");
        }

        [HttpGet]
        [Route("getdtoobject1")]
        [ProducesResponseType(typeof(DtoObject1), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetDtoObject1()
        {
            await Task.Delay(1000);
            return Ok(new DtoObject1 {Name = "GetDtoObject1" });
        }

        [HttpGet]
        [Route("getdtoobject2")]
        [ProducesResponseType(typeof(DtoObject2), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetDtoObject2()
        {
            await Task.Delay(2000);
            return Ok(new DtoObject2 { Name = "GetDtoObject2" });
        }

        [HttpGet]
        [Route("getdtoobject3")]
        [ProducesResponseType(typeof(DtoObject3), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetDtoObject3()
        {
            await Task.Delay(3000);
            return Ok(new DtoObject3 { Name = "GetDtoObject3" });
        }

        [HttpGet]
        [Route("get200")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Get200()
        {
            await Task.Delay(1000);
            return Ok("{ \"errorCode\": 200, \"errorMessage\": \"Ok\" }");
        }

        [HttpGet]
        [Route("get207")]
        [ProducesResponseType(StatusCodes.Status207MultiStatus)]
        [Produces("application/json")]
        public async Task<IActionResult> Get207()
        {
            await Task.Delay(1000);
            return StatusCode(207, "{ \"errorCode\": 207, \"errorMessage\": \"Partial Success\" }");
        }

        [HttpGet]
        [Route("get400")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> Get400()
        {
            await Task.Delay(1000);
            return BadRequest("{ \"errorCode\": 400, \"errorMessage\": \"Invalid request payload\" }");
        }

        [HttpGet]
        [Route("get409")]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [Produces("application/json")]
        public async Task<IActionResult> Get409()
        {
            await Task.Delay(1000);
            return Conflict("{ \"errorCode\": 409, \"errorMessage\": \"Request Already Submitted\" }");
        }

        [HttpGet]
        [Route("get500")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Get500()
        {
            await Task.Delay(1000);
            return StatusCode(StatusCodes.Status500InternalServerError, "{ \"errorCode\": 500, \"errorMessage\": \"Server error\" }");
        }
    }
}
