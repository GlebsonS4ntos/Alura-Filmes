using Alura.Data;
using Alura.Data.DTOs.GerenteDTOs;
using Alura.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private IMapper _mapper;
        private FilmeContext _context;

        public GerenteController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Gerente> ListarGerentes()
        {
            return _context.Gerentes;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarGerenteId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(x => x.GerenteId == id);
            if (gerente == null)
            {
                return NotFound();
            }
            HeadGerenteDTO headGerenteDTO = _mapper.Map<HeadGerenteDTO>(gerente);
            return Ok(headGerenteDTO);
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDTO dto)
        {
            Gerente g = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(g);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarGerenteId), new { Id = g.GerenteId }, g);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarGerente(int id, [FromBody] UpdateGerenteDTO updateDto)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(x => x.GerenteId == id);
            if (gerente != null)
            {
                _mapper.Map(updateDto, gerente);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(x => x.GerenteId == id);
            if (gerente != null)
            {
                _context.Gerentes.Remove(gerente);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}
