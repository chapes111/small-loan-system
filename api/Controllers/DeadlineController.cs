using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeadlineController : ControllerBase
    {
        private readonly rupert_investmentsContext _context;

        public DeadlineController(rupert_investmentsContext context)
        {
            _context = context;
        }

        // GET: api/Deadline
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deadline>>> GetDeadlines()
        {
            return await _context.Deadlines.ToListAsync();
        }

        // GET: api/Deadline/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deadline>> GetDeadline(DateTime id)
        {
            var deadline = await _context.Deadlines.FindAsync(id);

            if (deadline == null)
            {
                return NotFound();
            }

            return deadline;
        }

        // PUT: api/Deadline/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeadline(DateTime id, Deadline deadline)
        {
            if (id != deadline.AgreedDate)
            {
                return BadRequest();
            }

            _context.Entry(deadline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeadlineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Deadline
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deadline>> PostDeadline(Deadline deadline)
        {
            _context.Deadlines.Add(deadline);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeadlineExists(deadline.AgreedDate))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeadline", new { id = deadline.AgreedDate }, deadline);
        }

        // DELETE: api/Deadline/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeadline(DateTime id)
        {
            var deadline = await _context.Deadlines.FindAsync(id);
            if (deadline == null)
            {
                return NotFound();
            }

            _context.Deadlines.Remove(deadline);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeadlineExists(DateTime id)
        {
            return _context.Deadlines.Any(e => e.AgreedDate == id);
        }
    }
}
