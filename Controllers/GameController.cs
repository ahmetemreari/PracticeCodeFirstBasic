using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmrePracticeDbOne.Models;

namespace EmrePracticeDbOne.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly PatikaFirstDbContext _context;

        public GamesController(PatikaFirstDbContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get() => Ok(_context.Games);

        // GET: api/Games/{id}
        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            var game = _context.Games.FirstOrDefault(x => x.Id == id);
            if (game == null)
                return NotFound();
            return Ok(game);
        }

        // POST: api/Games
        [HttpPost]
        public IActionResult Post([FromBody] GameDto gameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var game = new Game
            {
                Name = gameDto.Name,
                Platform = gameDto.Platform,
                Rating = gameDto.Rating
            };

            _context.Games.Add(game);
            _context.SaveChanges();

            // Dönüşte DTO'yu döndürüyoruz.
            var responseDto = new GameDto
            {
                Name = game.Name,
                Platform = game.Platform,
                Rating = game.Rating
            };

            return CreatedAtAction(nameof(Get), new { id = game.Id }, responseDto);
        }

        // PUT: api/Games/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Game game)
        {
            if (id != game.Id)
                return BadRequest();

            _context.Entry(game).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Games/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
                return NotFound();

            _context.Games.Remove(game);
            _context.SaveChanges();
            return NoContent();
        }

        private bool GameExists(int id) => _context.Games.Any(e => e.Id == id);
    }
}