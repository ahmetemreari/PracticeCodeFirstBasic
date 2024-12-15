using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmrePracticeDbOne.Models;

namespace EmrePracticeDbOne.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly PatikaFirstDbContext _context;

        public MovieController(PatikaFirstDbContext context)
        {
            _context = context;
        }

        // GET: api/Movie
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get() => Ok(_context.Movies);

        // GET: api/Movie/{id}
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(movie);
        }

        // POST: api/Movie
        [HttpPost]
        public IActionResult Post([FromBody] MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movie = new Movie
            {
                Title = movieDto.Title,
                Genre = movieDto.Genre,
                ReleaseYear = movieDto.ReleaseYear
            };

            _context.Movies.Add(movie);
            _context.SaveChanges();

            // DTO olarak dönüş yap
            var responseDto = new MovieDto
            {
                Title = movie.Title,
                Genre = movie.Genre,
                ReleaseYear = movie.ReleaseYear
            };

            return CreatedAtAction(nameof(Get), new { id = movie.Id }, responseDto);
        }

        // PUT: api/Movie/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
            if (id != movie.Id)
                return BadRequest();

            _context.Entry(movie).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Movie/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }

        private bool MovieExists(int id) => _context.Movies.Any(e => e.Id == id);
    }
}