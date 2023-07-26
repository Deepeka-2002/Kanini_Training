using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Model;
using MovieAPI.Repository;

namespace MovieAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesInterface Mrepo;

        public MoviesController(IMoviesInterface Mrepo)
        {
            this.Mrepo = Mrepo;
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<Movies> Get()
        {
          return Mrepo.GetMovies();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public Movies GetMovies(int id)
        {

            return Mrepo.GetMovieById(id);
        }

        /*
        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovies(int id, Movies movies)
        {
            if (id != movies.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(movies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesExists(id))
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

        */
        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IEnumerable<Movies> AddMovies(Movies mov)
        {

            return Mrepo.AddMovies(mov);
        }

        /*
        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovies(int id)
        {
            if (_context.movies == null)
            {
                return NotFound();
            }
            var movies = await _context.movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }

            _context.movies.Remove(movies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoviesExists(int id)
        {
            return (_context.movies?.Any(e => e.MovieId == id)).GetValueOrDefault();
        }
        */
    }
}
