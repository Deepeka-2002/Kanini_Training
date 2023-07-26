using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Model;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreeningSchedulesController : ControllerBase
    {
        private readonly MovieContext _context;

        public ScreeningSchedulesController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/ScreeningSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScreeningSchedule>>> GetscreeningSchedules()
        {
          if (_context.screeningSchedules == null)
          {
              return NotFound();
          }
            return await _context.screeningSchedules.ToListAsync();
        }

        // GET: api/ScreeningSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScreeningSchedule>> GetScreeningSchedule(int id)
        {
          if (_context.screeningSchedules == null)
          {
              return NotFound();
          }
            var screeningSchedule = await _context.screeningSchedules.FindAsync(id);

            if (screeningSchedule == null)
            {
                return NotFound();
            }

            return screeningSchedule;
        }

        // PUT: api/ScreeningSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScreeningSchedule(int id, ScreeningSchedule screeningSchedule)
        {
            if (id != screeningSchedule.ScreeningId)
            {
                return BadRequest();
            }

            _context.Entry(screeningSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScreeningScheduleExists(id))
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

        // POST: api/ScreeningSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScreeningSchedule>> PostScreeningSchedule(ScreeningSchedule screeningSchedule)
        {
          if (_context.screeningSchedules == null)
          {
              return Problem("Entity set 'MovieContext.screeningSchedules'  is null.");
          }
            _context.screeningSchedules.Add(screeningSchedule);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ScreeningScheduleExists(screeningSchedule.ScreeningId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetScreeningSchedule", new { id = screeningSchedule.ScreeningId }, screeningSchedule);
        }

        // DELETE: api/ScreeningSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreeningSchedule(int id)
        {
            if (_context.screeningSchedules == null)
            {
                return NotFound();
            }
            var screeningSchedule = await _context.screeningSchedules.FindAsync(id);
            if (screeningSchedule == null)
            {
                return NotFound();
            }

            _context.screeningSchedules.Remove(screeningSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScreeningScheduleExists(int id)
        {
            return (_context.screeningSchedules?.Any(e => e.ScreeningId == id)).GetValueOrDefault();
        }
    }
}
