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
    public class IntermediaryController : ControllerBase
    {
        private readonly rupert_investmentsContext _context;

        public IntermediaryController(rupert_investmentsContext context)
        {
            _context = context;
        }

        // GET: api/Intermediary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intermediary>>> GetIntermediaries()
        {
            return await _context.Intermediaries.ToListAsync();
        }

        // GET: api/Intermediary/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intermediary>> GetIntermediary(int id)
        {
            var intermediary = await _context.Intermediaries.FindAsync(id);

            if (intermediary == null)
            {
                return NotFound();
            }

            return intermediary;
        }

        // PUT: api/Intermediary/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntermediary(int id, Intermediary intermediary)
        {
            if (id != intermediary.Id)
            {
                return BadRequest();
            }

            _context.Entry(intermediary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntermediaryExists(id))
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

        // POST: api/Intermediary
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Intermediary>> PostIntermediary(Intermediary intermediary)
        {
            _context.Intermediaries.Add(intermediary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntermediary", new { id = intermediary.Id }, intermediary);
        }

        // DELETE: api/Intermediary/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntermediary(int id)
        {
            var intermediary = await _context.Intermediaries.FindAsync(id);
            if (intermediary == null)
            {
                return NotFound();
            }

            _context.Intermediaries.Remove(intermediary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IntermediaryExists(int id)
        {
            return _context.Intermediaries.Any(e => e.Id == id);
        }
    }
}
