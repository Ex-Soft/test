using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Get values
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get a specific value
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Create a value
        /// </summary>
        [HttpPost]
        public ActionResult<string> Post([FromBody] string value)
        {
            return value;
        }

        /// <summary>
        /// Update a specific value
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] string value)
        {
            return value;
        }

        /// <summary>
        /// Delete a specific value
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            return id;
        }
    }
}