using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AnyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"value {id}";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Victim value)
        {
            Debug.WriteLine($"Post: {{value:\"{value.Value}\"}}");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Victim value)
        {
            Debug.WriteLine($"Put: {{id:{id}, value:\"{value.Value}\"}}");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Debug.WriteLine($"Delete: {{id:{id}}}");
        }
    }

    public class Victim
    {
        public string Value { get; set; }
    }
}
