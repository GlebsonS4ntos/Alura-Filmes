using Alura.Data;
using Alura.Data.DTOs.FilmeDTOs;
using Alura.Models;
using Alura.Services;
using AutoMapper;
using FluentResults;
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
        public FilmeService _service;
        public FilmeController(FilmeService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CadastrarFilme([FromBody]CreateFilmeDTO filmeDTO)
        {
            //conversão usando o mapper, de um createdFilmeDTO para o tipo Filme
            HeadFilmeDTO filmeDto = _service.AdicionarFilme(filmeDTO);
            return CreatedAtAction(nameof(BuscarFilmePorId), new {Id = filmeDto.FilmeId}, filmeDto);
        }

        [HttpGet]
        public IActionResult ListarFilme([FromQuery] int? classificacaoIndicativa = null)
        {
            List<HeadFilmeDTO> filmesDTO = _service.ListarFilme(classificacaoIndicativa);
            if(filmesDTO != null) return Ok(filmesDTO);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilmePorId(int id)
        {
            HeadFilmeDTO headFilme = _service.BuscarFilmePorId(id);
            if(headFilme != null) return Ok(headFilme);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
        {
            Result resultado = _service.AtualizarFilme(filmeDTO, id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverFilme(int id)
        {
            Result resultado = _service.RemoverFilme(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
