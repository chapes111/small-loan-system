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
    public class BorrowerController : ControllerBase
    {
        private readonly rupert_investmentsContext _context;

        public BorrowerController(rupert_investmentsContext context)
        {
            _context = context;
        }

        // GET: api/Borrower
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Borrower>>> GetBorrowers()
        {
            return await _context.Borrowers.ToListAsync();
        }

        // GET: api/Borrower/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Borrower>> GetBorrower(int id)
        {
            var borrower = await _context.Borrowers.FindAsync(id);

            if (borrower == null)
            {
                return NotFound();
            }

            return borrower;
        }

        // PUT: api/Borrower/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrower(int id, Borrower borrower)
        {
            if (id != borrower.Id)
            {
                return BadRequest();
            }

            _context.Entry(borrower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowerExists(id))
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

        // POST: api/Borrower
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Borrower>> PostBorrower(Borrower borrower)
        {
            _context.Borrowers.Add(borrower);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBorrower", new { id = borrower.Id }, borrower);
        }

        // DELETE: api/Borrower/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrower(int id)
        {
            var borrower = await _context.Borrowers.FindAsync(id);
            if (borrower == null)
            {
                return NotFound();
            }

            _context.Borrowers.Remove(borrower);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BorrowerExists(int id)
        {
            return _context.Borrowers.Any(e => e.Id == id);
        }
    }
}
