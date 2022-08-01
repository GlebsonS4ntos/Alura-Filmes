using Alura.Data;
using Alura.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemasController : ControllerBase
    {
        private readonly FilmeContext _context;

        public CinemasController(FilmeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Cinema> BuscarCinemas()
        {
            return _context.Cinemas;
        }

        [HttpGet("{id}")]
        public IActionResult BuscaCinemaId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.CinemaId == id);
            if (cinema == null)
            {
                return NotFound();
            }
            return Ok(cinema);
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] Cinema c)
        {
            _context.Cinemas.Add(c);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaCinemaId), new {Id = c.CinemaId }, c);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] Cinema c)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.CinemaId == id);
            if(cinema == null)
            {
                return NotFound();
            }
            cinema.CinemaName = c.CinemaName;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Cinema c = _context.Cinemas.FirstOrDefault(x => x.CinemaId == id);
            if (c == null)
            {
                return NotFound();
            }
            _context.Cinemas.Remove(c);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
