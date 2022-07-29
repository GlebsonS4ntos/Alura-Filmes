using Alura.Data;
using Alura.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CadastrarFilme([FromBody]Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarFilmePorId), new {Id = filme.FilmeId}, filme);
        }
        [HttpGet]
        public IEnumerable<Filme> ListarFilme()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilmePorId(int id)
        {
            Filme f =  _context.Filmes.FirstOrDefault(x => x.FilmeId == id);
            if(f != null)
            {
                return Ok(f);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] Filme filme)
        {
            Filme f = _context.Filmes.FirstOrDefault(x => x.FilmeId == id);
            if(f == null)
            {
                return NotFound();
            }
            f.FilmeName = filme.FilmeName;
            f.Duracao = filme.Duracao;
            f.Diretor = filme.Diretor;
            f.Genero = filme.Genero;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverFilme(int id)
        {
            Filme f = _context.Filmes.FirstOrDefault(x => x.FilmeId == id);
            if (f == null)
            {
                return NotFound();
            }
            _context.Remove(f);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
