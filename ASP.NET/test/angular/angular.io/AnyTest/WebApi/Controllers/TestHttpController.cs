//https://blog.angular-university.io/angular-http/

using System.Threading.Tasks;
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
            return Ok(new DtoObject1 { Name = "GetDtoObject2" });
        }

        [HttpGet]
        [Route("getdtoobject3")]
        public async Task<IActionResult> GetDtoObject3()
        {
            await Task.Delay(3000);
            return Ok(new DtoObject1 { Name = "GetDtoObject3" });
        }
    }
}
