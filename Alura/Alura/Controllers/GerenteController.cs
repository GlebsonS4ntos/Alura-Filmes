using Alura.Data;
using Alura.Data.DTOs.GerenteDTOs;
using Alura.Models;
using Alura.Services;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _service;

        public GerenteController(GerenteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult ListarGerentes()
        {
            List<HeadGerenteDTO> dtos = _service.ListarGerentes();
            if(dtos == null) return NotFound();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarGerenteId(int id)
        {
            HeadGerenteDTO dto = _service.BuscarGerenteId(id);
            if(dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDTO dto)
        {
            HeadGerenteDTO headDto = _service.AdicionarGerente(dto); 
            return CreatedAtAction(nameof(BuscarGerenteId), new { Id = headDto.GerenteId }, headDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarGerente(int id, [FromBody] UpdateGerenteDTO updateDto)
        {
            Result resultado = _service.AtualizarGerente(id, updateDto);
            if(resultado != null) return NoContent();
            return NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Result resultado = _service.DeletarGerente(id);
            if(resultado != null ) return NoContent();
            return NotFound();
        }
    }
}
