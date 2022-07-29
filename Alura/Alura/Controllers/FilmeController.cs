using Alura.Data;
using Alura.Data.DTOs;
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
        public IActionResult CadastrarFilme([FromBody]CreateFilmeDTO filmeDTO)
        {
            Filme filme = new()
            {
                FilmeName = filmeDTO.FilmeName,
                Duracao = filmeDTO.Duracao,
                Genero = filmeDTO.Genero,
                Diretor = filmeDTO.Diretor
            };
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
                HeadFilmeDTO filmeDTO = new() 
                { 
                    FilmeId = f.FilmeId,
                    Duracao = f.Duracao,
                    Diretor = f.Diretor,
                    Genero = f.Genero,
                    FilmeName = f.FilmeName,
                    DataConsulta = DateTime.Now
                };

                return Ok(filmeDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
        {
            Filme f = _context.Filmes.FirstOrDefault(x => x.FilmeId == id);
            if(f == null)
            {
                return NotFound();
            }
            f.FilmeName = filmeDTO.FilmeName;
            f.Duracao = filmeDTO.Duracao;
            f.Diretor = filmeDTO.Diretor;
            f.Genero = filmeDTO.Genero;

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
