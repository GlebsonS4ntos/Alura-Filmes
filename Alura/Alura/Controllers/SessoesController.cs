using Alura.Data;
using Alura.Data.DTOs.GerenteDTOs;
using Alura.Data.DTOs.SessaoDTOs;
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
    public class SessoesController : ControllerBase
    {
        private SessaoService _service;

        public SessoesController(SessaoService service)
        {
           _service = service;
        }

        [HttpGet]
        public IActionResult TodasSessoes()
        {
            List<HeadSessaoDTO> dto = _service.TodasSessoes();
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarSessaoPorId(int id)
        {
            HeadSessaoDTO dto = _service.BuscarSessaoPorId(id);
            if(dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDTO sessaoDto)
        {
            HeadSessaoDTO dto = _service.AdicionarSessao(sessaoDto);
            return CreatedAtAction(nameof(BuscarSessaoPorId), new {Id = dto.SessaoId}, dto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSessao(int id, [FromBody] UpdateSessaoDTO updateDto)
        {
            Result resultado = _service.AtualizarSessao(id, updateDto);
            if(resultado.IsSuccess) return NoContent();
            return NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarSessao(int id)
        {
            Result resultado = _service.DeletarSessao(id);
            if(resultado.IsSuccess) return NoContent();
            return NotFound();
        }
    }
}
