using Alura.Data;
using Alura.Data.DTOs.CinemaDTOs;
using Alura.Models;
using Alura.Services;
using AutoMapper;
using FluentResults;
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
        private CinemaService _service; 

        public CinemasController(CinemaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult BuscarCinemas([FromQuery] string nomeFilme)
        {
            List<HeadCinemaDTO> headDTO = _service.BuscarCinemas(nomeFilme);
            if(headDTO == null) return NotFound();
            return Ok(headDTO);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaCinemaId(int id)
        {
            HeadCinemaDTO dto = _service.BuscarCinemaId(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody]CreatedCinemaDTO c)
        {
            HeadCinemaDTO dto = _service.AdicionarCinema(c);
            return CreatedAtAction(nameof(BuscaCinemaId), new {Id = dto.CinemaId }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDTO c)
        {
            Result resultado = _service.AtualizarCinema(c, id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Result resultado = _service.DeletarCinema(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
