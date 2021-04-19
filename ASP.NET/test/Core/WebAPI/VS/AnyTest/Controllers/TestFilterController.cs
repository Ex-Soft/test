using System.Threading.Tasks;
using AnyTest.Filters;
using AnyTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestFilterController : ControllerBase
    {
        [HttpPost]
        [Route("testactionfilterbyservicefilter")]
        [ServiceFilter(typeof(ActionFilterExample))]
        public ActionResult<Victim> TestActionFilterByServiceFilter([FromBody] Victim victim)
        {
            System.Diagnostics.Debug.WriteLine("TestFilterController.TestActionFilterByServiceFilter()");
            return Ok(victim);
        }

        [HttpPost]
        [Route("testasyncactionfilterbyservicefilter")]
        [ServiceFilter(typeof(AsyncActionFilterExample))]
        public async Task<ActionResult<Victim>> TestAsyncActionFilterByServiceFilter([FromBody] Victim victim)
        {
            await Task.Delay(1000);
            System.Diagnostics.Debug.WriteLine("TestFilterController.TestAsyncActionFilterByServiceFilter()");
            return Ok(victim);
        }

        [HttpPost]
        [Route("testactionfilterbyattribute")]
        [ActionFilterExample("victim")]
        public ActionResult<Victim> TestActionFilterByAttribute([FromBody] Victim victim)
        {
            System.Diagnostics.Debug.WriteLine("TestFilterController.TestActionFilterByAttribute()");
            return Ok(victim);
        }

        [HttpPost]
        [Route("testasyncactionfilterbyattribute")]
        [AsyncActionFilterExample("victim")]
        public async Task<ActionResult<Victim>> TestAsyncActionFilterByAttribute([FromBody] Victim victim)
        {
            await Task.Delay(1000);
            System.Diagnostics.Debug.WriteLine("TestFilterController.TestAsyncActionFilterByAttribute()");
            return Ok(victim);
        }

        [HttpPost]
        [Route("testactionfilterdi")]
        [ServiceFilter(typeof(ActionFilterDIExample))]
        public ActionResult<Victim> TestActionFilterDI([FromBody] Victim victim)
        {
            System.Diagnostics.Debug.WriteLine("TestFilterController.TestActionFilterDI()");
            return Ok(victim);
        }

        [HttpPost]
        [Route("testasyncactionfilterdi")]
        [ServiceFilter(typeof(AsyncActionFilterDIExample))]
        public async Task<ActionResult<Victim>> TestAsyncActionFilterDI([FromBody] Victim victim)
        {
            await Task.Delay(1000);
            System.Diagnostics.Debug.WriteLine("TestFilterController.TestAsyncActionFilterDI()");
            return Accepted(victim);
        }
    }
}
