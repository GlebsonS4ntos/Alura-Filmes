using Alura.Data;
using Alura.Data.DTOs.EnderecoDTOs;
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
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _service;

        public EnderecoController(EnderecoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CadastrarEndereco([FromBody]CreateEnderecoDTO enderecoDTO)
        {
            HeadEnderecoDTO head = _service.CadastrarEndereco(enderecoDTO); 
            return CreatedAtAction(nameof(BuscarEnderecoPorId), new {Id = head.EnderecoId}, head);
        }

        [HttpGet]
        public IActionResult ListarEndereco()
        {
            List<HeadEnderecoDTO> lista = _service.ListarEndereco();
            if (lista == null) return NoContent();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarEnderecoPorId(int id)
        {
            HeadEnderecoDTO dto = _service.BuscarEnderecoId(id);
            if (dto == null) return NoContent();
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDTO)
        {
            Result resultado = _service.AtualizarEndereco(id, enderecoDTO);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverEmdereco(int id)
        {
            Result resultado = _service.RemoverEndereco(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
