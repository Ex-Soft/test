using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ValueController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [Route("TestClass1")]
        public async Task<ActionResult<Class1Response>> TestClass1([FromBody] Class1Request request)
        {
            Class1Dto dto = _mapper.Map<Class1Dto>(request);
            Class1Response response = _mapper.Map<Class1Response>(dto);
            await Task.Delay(1000);
            return Ok(response);
        }

        [HttpPost]
        [Route("TestClass2")]
        public async Task<ActionResult<Class2Response>> TestClass2([FromBody] Class2Request request)
        {
            Class2Dto dto = _mapper.Map<Class2Dto>(request);
            Class2Response response = _mapper.Map<Class2Response>(dto);
            await Task.Delay(1000);
            return new ObjectResult(response) { StatusCode = 200 };
        }
    }
}
