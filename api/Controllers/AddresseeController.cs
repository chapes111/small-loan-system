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
    public class AddresseeController : ControllerBase
    {
        private readonly rupert_investmentsContext _context;

        public AddresseeController(rupert_investmentsContext context)
        {
            _context = context;
        }

        // GET: api/Addressee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Addressee>>> GetAddressees()
        {
            return await _context.Addressees.ToListAsync();
        }

        // GET: api/Addressee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Addressee>> GetAddressee(int id)
        {
            var addressee = await _context.Addressees.FindAsync(id);

            if (addressee == null)
            {
                return NotFound();
            }

            return addressee;
        }

        // PUT: api/Addressee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressee(int id, Addressee addressee)
        {
            if (id != addressee.Id)
            {
                return BadRequest();
            }

            _context.Entry(addressee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddresseeExists(id))
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

        // POST: api/Addressee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Addressee>> PostAddressee(Addressee addressee)
        {
            _context.Addressees.Add(addressee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddressee", new { id = addressee.Id }, addressee);
        }

        // DELETE: api/Addressee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressee(int id)
        {
            var addressee = await _context.Addressees.FindAsync(id);
            if (addressee == null)
            {
                return NotFound();
            }

            _context.Addressees.Remove(addressee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddresseeExists(int id)
        {
            return _context.Addressees.Any(e => e.Id == id);
        }
    }
}
