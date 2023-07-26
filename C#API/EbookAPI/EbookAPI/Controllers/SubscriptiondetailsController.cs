using EbookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptiondetailsController : ControllerBase
    {
        private readonly EbookContext _context;

        public SubscriptiondetailsController(EbookContext context) 
        { 
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscriptiondetail>>> GetSubscriptiondetails()
        {
            if (_context.Subscriptiondetails == null)
            {
                return NotFound();
            }
            return await _context.Subscriptiondetails.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscriptiondetail>> GetSubscriptiondetail(int id)
        {
            if (_context.Subscriptiondetails == null)
            {
                return NotFound();
            }
            var subscriptiondetail = await _context.Subscriptiondetails.FindAsync(id);

            if (subscriptiondetail == null)
            {
                return NotFound();
            }

            return subscriptiondetail;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptiondetail(int id, Subscriptiondetail subscriptiondetail)
        {
            if (id != subscriptiondetail.Userid)
            {
                return BadRequest();
            }

            _context.Entry(subscriptiondetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptiondetailExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subscriptiondetail>> PostSubscriptiondetail(Subscriptiondetail subscriptiondetail)
        {
            if (_context.Subscriptiondetails == null)
            {
                return Problem("Entity set 'EbookContext.Subscriptiondetails'  is null.");
            }
            _context.Subscriptiondetails.Add(subscriptiondetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriptiondetail", new { id = subscriptiondetail.Userid }, subscriptiondetail);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptiondetail(int id)
        {
            if (_context.Subscriptiondetails == null)
            {
                return NotFound();
            }
            var subscriptiondetail = await _context.Subscriptiondetails.FindAsync(id);
            if (subscriptiondetail == null)
            {
                return NotFound();
            }

            _context.Subscriptiondetails.Remove(subscriptiondetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriptiondetailExists(int id)
        {
            return (_context.Subscriptiondetails?.Any(e => e.Userid == id)).GetValueOrDefault();
        }
    }
}

  
