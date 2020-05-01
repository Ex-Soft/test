using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Staff>> Get()
        {
            return await _context.Staffs.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Staff>> Get(long id)
        {
            var staff = await _context.Staffs.FindAsync(id);

            if (staff == null)
                return NotFound();

            return Ok(staff);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Staff>> Post([FromBody] Staff staff)
        {
            if (staff == null)
                return NotFound();

            if (staff.Id != 0)
            {
                var _staff = await _context.Staffs.FindAsync(staff.Id);
                if (_staff != null)
                    return Conflict();
            }

            staff.Id = 0;
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = staff.Id }, staff);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(long id, [FromBody] Staff staff)
        {
            if (id == 0 || staff == null)
                return NoContent();
            
            if (id != staff.Id)
                return BadRequest();

            var _staff = await _context.Staffs.FindAsync(id);
            if (_staff == null)
                return NotFound();
            
            _staff.Name = staff.Name;
            _staff.Salary = staff.Salary;
            _staff.Dep = staff.Dep;
            _staff.BirthDate = staff.BirthDate;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
                    return NotFound();
                else
                    throw;
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(long id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
                return NotFound();

            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();

            return Ok();
        }

        bool StaffExists(long id)
        {
            return _context.Staffs.Any(e => e.Id == id);
        }
    }
}
