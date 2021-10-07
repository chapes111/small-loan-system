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
    public class LenderBorrowerController : ControllerBase
    {
        private readonly rupert_investmentsContext _context;

        public LenderBorrowerController(rupert_investmentsContext context)
        {
            _context = context;
        }

        // GET: api/LenderBorrower
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LenderBorrower>>> GetLenderBorrowers()
        {
            return await _context.LenderBorrowers.ToListAsync();
        }

        // GET: api/LenderBorrower/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LenderBorrower>> GetLenderBorrower(int id)
        {
            var lenderBorrower = await _context.LenderBorrowers.FindAsync(id);

            if (lenderBorrower == null)
            {
                return NotFound();
            }

            return lenderBorrower;
        }

        // PUT: api/LenderBorrower/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLenderBorrower(int id, LenderBorrower lenderBorrower)
        {
            if (id != lenderBorrower.BorrowerId)
            {
                return BadRequest();
            }

            _context.Entry(lenderBorrower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LenderBorrowerExists(id))
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

        // POST: api/LenderBorrower
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LenderBorrower>> PostLenderBorrower(LenderBorrower lenderBorrower)
        {
            _context.LenderBorrowers.Add(lenderBorrower);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LenderBorrowerExists(lenderBorrower.BorrowerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLenderBorrower", new { id = lenderBorrower.BorrowerId }, lenderBorrower);
        }

        // DELETE: api/LenderBorrower/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLenderBorrower(int id)
        {
            var lenderBorrower = await _context.LenderBorrowers.FindAsync(id);
            if (lenderBorrower == null)
            {
                return NotFound();
            }

            _context.LenderBorrowers.Remove(lenderBorrower);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LenderBorrowerExists(int id)
        {
            return _context.LenderBorrowers.Any(e => e.BorrowerId == id);
        }
    }
}
