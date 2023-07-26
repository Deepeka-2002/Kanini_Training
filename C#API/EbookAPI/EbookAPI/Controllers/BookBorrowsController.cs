using EbookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookBorrowsController : ControllerBase
    {
        private readonly EbookContext _context;

        public BookBorrowsController(EbookContext context)
        {
            _context = context; 
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookBorrow>>> GetBookBorrows()
        {
            if (_context.BookBorrows == null)
            {
                return NotFound();
            }
            return await _context.BookBorrows.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookBorrow>> GetBookBorrow(int id)
        {
            if (_context.BookBorrows == null)
            {
                return NotFound();
            }
            var BookBorrow = await _context.BookBorrows.FindAsync(id);

            if (BookBorrow == null)
            {
                return NotFound();
            }

            return BookBorrow;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookBorrow(int id, BookBorrow bookBorrow)
        {
            if (id != bookBorrow.Borrowid)
            {
                return BadRequest();
            }

            _context.Entry(bookBorrow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bookBorrowExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookBorrow>> PostBookBorrow(BookBorrow bookBorrow)
        {
            if (_context.BookBorrows== null)
            {
                return Problem("Entity set 'EbookContext.BookBorrows'  is null.");
            }
            _context.BookBorrows.Add(bookBorrow);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (bookBorrowExists(bookBorrow.Borrowid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookBorrow", new { id = bookBorrow.Borrowid }, bookBorrow);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookBorrow(int id)
        {
            if (_context.BookBorrows == null)
            {
                return NotFound();
            }
            var bookBorrow = await _context.BookBorrows.FindAsync(id);
            if (bookBorrow == null)
            {
                return NotFound();
            }

            _context.BookBorrows.Remove(bookBorrow);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool bookBorrowExists(int id)
        {
            return (_context.BookBorrows?.Any(e => e.Borrowid == id)).GetValueOrDefault();
        }
    }
}

  
