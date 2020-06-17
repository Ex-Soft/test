using System.Collections.Generic;
using DbService.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbController : ControllerBase
    {
        private readonly Services.DbService _dbService;

        public DbController(Services.DbService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet]
        public ActionResult<List<Staff>> Get() =>
            _dbService.Get();

        [HttpGet("{id:length(24)}", Name = "GetStaff")]
        public ActionResult<Staff> Get(string id)
        {
            var staff = _dbService.Get(id);

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

        [HttpPost]
        public ActionResult<Staff> Create(Staff staff)
        {
            _dbService.Create(staff);

            return CreatedAtRoute("GetStaff", new { id = staff.Id }, staff);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Staff staffIn)
        {
            var staff = _dbService.Get(id);

            if (staff == null)
            {
                return NotFound();
            }

            _dbService.Update(id, staffIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var staff = _dbService.Get(id);

            if (staff == null)
            {
                return NotFound();
            }

            _dbService.Remove(staff.Id);

            return NoContent();
        }
    }
}
