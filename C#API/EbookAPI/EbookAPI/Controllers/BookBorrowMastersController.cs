using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EbookAPI.Models;

namespace EbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookBorrowMastersController : ControllerBase
    {
        private readonly EbookContext _context;

        public BookBorrowMastersController(EbookContext context)
        {
            _context = context;
        }

        // GET: api/BookBorrowMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookBorrowMaster>>> GetBookBorrowMasters()
        {
          if (_context.BookBorrowMasters == null)
          {
              return NotFound();
          }
            return await _context.BookBorrowMasters.ToListAsync();
        }

        // GET: api/BookBorrowMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookBorrowMaster>> GetBookBorrowMaster(int id)
        {
          if (_context.BookBorrowMasters == null)
          {
              return NotFound();
          }
            var bookBorrowMaster = await _context.BookBorrowMasters.FindAsync(id);

            if (bookBorrowMaster == null)
            {
                return NotFound();
            }

            return bookBorrowMaster;
        }

        // PUT: api/BookBorrowMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookBorrowMaster(int id, BookBorrowMaster bookBorrowMaster)
        {
            if (id != bookBorrowMaster.Borrowid)
            {
                return BadRequest();
            }

            _context.Entry(bookBorrowMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookBorrowMasterExists(id))
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

        // POST: api/BookBorrowMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookBorrowMaster>> PostBookBorrowMaster(BookBorrowMaster bookBorrowMaster)
        {
          if (_context.BookBorrowMasters == null)
          {
              return Problem("Entity set 'EbookContext.BookBorrowMasters'  is null.");
          }
            _context.BookBorrowMasters.Add(bookBorrowMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookBorrowMaster", new { id = bookBorrowMaster.Borrowid }, bookBorrowMaster);
        }

        // DELETE: api/BookBorrowMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookBorrowMaster(int id)
        {
            if (_context.BookBorrowMasters == null)
            {
                return NotFound();
            }
            var bookBorrowMaster = await _context.BookBorrowMasters.FindAsync(id);
            if (bookBorrowMaster == null)
            {
                return NotFound();
            }

            _context.BookBorrowMasters.Remove(bookBorrowMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookBorrowMasterExists(int id)
        {
            return (_context.BookBorrowMasters?.Any(e => e.Borrowid == id)).GetValueOrDefault();
        }
    }
}
