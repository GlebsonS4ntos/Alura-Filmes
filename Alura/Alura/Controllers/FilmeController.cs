﻿using Alura.Data;
using Alura.Data.DTOs;
using Alura.Models;
using AutoMapper;
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
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CadastrarFilme([FromBody]CreateFilmeDTO filmeDTO)
        {
            //conversão usando o mapper, de um createdFilmeDTO para o tipo Filme
            Filme filme = _mapper.Map<Filme>(filmeDTO);
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
                HeadFilmeDTO filmeDTO = _mapper.Map<HeadFilmeDTO>(f);
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
            _mapper.Map(filmeDTO, f); //jogando as informações do filmeDTO pra o f

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
