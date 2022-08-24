using Alura.Data;
using Alura.Data.DTOs.GerenteDTOs;
using Alura.Data.DTOs.SessaoDTOs;
using Alura.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessoesController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessoesController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Sessao> TodasSessoes()
        {
            return _context.Sessoes;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarSessaoPorId(int Id)
        {
            Sessao s = _context.Sessoes.FirstOrDefault(x => x.SessaoId == Id);
            if( s == null)
            {
                return NotFound();
            }
            HeadSessaoDTO headSessao = _mapper.Map<HeadSessaoDTO>(s);
            return Ok(headSessao);
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDTO sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges(); 
            return CreatedAtAction(nameof(BuscarSessaoPorId), new {Id = sessao.SessaoId}, sessao);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSessao(int id, [FromBody] UpdateSessaoDTO updateDto)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(x => x.SessaoId == id);
            if (sessao != null)
            {
                _mapper.Map(updateDto, sessao);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarSessao(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(x => x.SessaoId == id);
            if (sessao != null)
            {
                _context.Sessoes.Remove(sessao);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}
