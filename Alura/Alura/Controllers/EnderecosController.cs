using Alura.Data;
using Alura.Data.DTOs.EnderecoDTOs;
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
    public class EnderecoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CadastrarEndereco([FromBody]CreateEnderecoDTO enderecoDTO)
        {
            //conversão usando o mapper, de um createdEnderecoDTO para o tipo Endereco
            Endereco e = _mapper.Map<Endereco>(enderecoDTO);
            _context.Enderecos.Add(e);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarEnderecoPorId), new {Id = e.EnderecoId}, e);
        }

        [HttpGet]
        public IEnumerable<Endereco> ListarEmdereco()
        {
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarEnderecoPorId(int id)
        {
            Endereco e =  _context.Enderecos.FirstOrDefault(x => x.EnderecoId == id);
            if(e != null)
            {
                HeadEnderecoDTO enderecoDTO = _mapper.Map<HeadEnderecoDTO>(e);
                return Ok(enderecoDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDTO)
        {
            Endereco e = _context.Enderecos.FirstOrDefault(x => x.EnderecoId == id);
            if(e == null)
            {
                return NotFound();
            }
            _mapper.Map(enderecoDTO, e); //jogando as informações do enderecoDTO para o e
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverEmdereco(int id)
        {
            Endereco e = _context.Enderecos.FirstOrDefault(x => x.EnderecoId == id);
            if (e == null)
            {
                return NotFound();
            }
            _context.Enderecos.Remove(e);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
