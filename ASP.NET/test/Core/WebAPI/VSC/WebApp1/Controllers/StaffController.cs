using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        readonly TestDbContext _context;

        public StaffController(TestDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Staff> Get()
        {
            return _context.Staffs.ToArray();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Staff> Get(long id)
        {
            var staff = _context.Staffs.FirstOrDefault(e => e.Id == id);

            if (staff == null)
                return NotFound();

            return Ok(staff);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<Staff> Post([FromBody] Staff staff)
        {
            if (staff == null)
                return NotFound();

            if (staff.Id != 0 && _context.Staffs.FirstOrDefault(e => e.Id == staff.Id) != null)
                return Conflict();

            staff.Id = 0;
            _context.Staffs.Add(staff);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = staff.Id }, staff);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(long id, [FromBody] Staff staff)
        {
            if (id == 0 || staff == null)
                return NoContent();
            
            var _staff = _context.Staffs.FirstOrDefault(e => e.Id == id);
            if (_staff == null)
                return NotFound();
            
            _staff.Name = staff.Name;
            _staff.Salary = staff.Salary;
            _staff.Dep = staff.Dep;
            _staff.BirthDate = staff.BirthDate;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(long id)
        {
            var _staff = _context.Staffs.FirstOrDefault(e => e.Id == id);
            if (_staff == null)
                return NotFound();

            _context.Staffs.Remove(_staff);
            _context.SaveChanges();

            return Ok();
        }
    }
}
