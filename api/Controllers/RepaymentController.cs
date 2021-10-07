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
    public class RepaymentController : ControllerBase
    {
        private readonly rupert_investmentsContext _context;

        public RepaymentController(rupert_investmentsContext context)
        {
            _context = context;
        }

        // GET: api/Repayment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repayment>>> GetRepayments()
        {
            return await _context.Repayments.ToListAsync();
        }

        // GET: api/Repayment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Repayment>> GetRepayment(DateTime id)
        {
            var repayment = await _context.Repayments.FindAsync(id);

            if (repayment == null)
            {
                return NotFound();
            }

            return repayment;
        }

        // PUT: api/Repayment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepayment(DateTime id, Repayment repayment)
        {
            if (id != repayment.Date)
            {
                return BadRequest();
            }

            _context.Entry(repayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepaymentExists(id))
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

        // POST: api/Repayment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Repayment>> PostRepayment(Repayment repayment)
        {
            _context.Repayments.Add(repayment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RepaymentExists(repayment.Date))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRepayment", new { id = repayment.Date }, repayment);
        }

        // DELETE: api/Repayment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepayment(DateTime id)
        {
            var repayment = await _context.Repayments.FindAsync(id);
            if (repayment == null)
            {
                return NotFound();
            }

            _context.Repayments.Remove(repayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepaymentExists(DateTime id)
        {
            return _context.Repayments.Any(e => e.Date == id);
        }
    }
}
