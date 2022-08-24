using Alura.Data;
using Alura.Data.DTOs.CinemaDTOs;
using Alura.Models;
using AutoMapper;
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
        private FilmeContext _context;
        private IMapper _mapper; 

        public CinemasController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BuscarCinemas([FromQuery] string nomeFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if(cinemas == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(nomeFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                        where cinema.Sessoes.Any(sessao => 
                        sessao.Filme.FilmeName.ToUpper() == nomeFilme.ToUpper())
                        select cinema;
                cinemas = query.ToList();
            }
            List<HeadCinemaDTO> headDTO = _mapper.Map<List<HeadCinemaDTO>>(cinemas);
            return Ok(headDTO);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaCinemaId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.CinemaId == id);
            if (cinema == null)
            {
                return NotFound();
            }
            HeadCinemaDTO cinemaDto = _mapper.Map<HeadCinemaDTO>(cinema); 
            return Ok(cinemaDto);
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody]CreatedCinemaDTO c)
        {
            Cinema cinema = _mapper.Map<Cinema>(c);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaCinemaId), new {Id = cinema.CinemaId }, cinema);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDTO c)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.CinemaId == id);
            if(cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(c, cinema);
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
