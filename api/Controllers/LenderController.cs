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
    public class LenderController : ControllerBase
    {
        private readonly rupert_investmentsContext _context;

        public LenderController(rupert_investmentsContext context)
        {
            _context = context;
        }

        // GET: api/Lender
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lender>>> GetLenders()
        {
            return await _context.Lenders.ToListAsync();
        }

        // GET: api/Lender/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lender>> GetLender(int id)
        {
            var lender = await _context.Lenders.FindAsync(id);

            if (lender == null)
            {
                return NotFound();
            }

            return lender;
        }

        // PUT: api/Lender/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLender(int id, Lender lender)
        {
            if (id != lender.Id)
            {
                return BadRequest();
            }

            _context.Entry(lender).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LenderExists(id))
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

        // POST: api/Lender
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lender>> PostLender(Lender lender)
        {
            _context.Lenders.Add(lender);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLender", new { id = lender.Id }, lender);
        }

        // DELETE: api/Lender/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLender(int id)
        {
            var lender = await _context.Lenders.FindAsync(id);
            if (lender == null)
            {
                return NotFound();
            }

            _context.Lenders.Remove(lender);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LenderExists(int id)
        {
            return _context.Lenders.Any(e => e.Id == id);
        }
    }
}
