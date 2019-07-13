using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<PersonnelResponse> Get()
        {
            var data = new Personnel[]
            {
                new Personnel(1, "Jean Luc", "jeanluc.picard@enterprise.com", "555-111-1111"),
                new Personnel(2, "Worf", "worf.moghsson@enterprise.com", "555-222-2222"),
                new Personnel(3, "Deanna", "deanna.troi@enterprise.com", "555-333-3333"),
                new Personnel(4, "Data", "mr.data@enterprise.com", "555-444-4444")
            };

            return new PersonnelResponse(true, data, data.Length, "message");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"value{id}";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] string value)
        {
            return value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] string value)
        {
            return $"{id} {value}";
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            return id.ToString();
        }
    }
}
