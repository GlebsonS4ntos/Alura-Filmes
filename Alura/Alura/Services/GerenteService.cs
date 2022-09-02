using Alura.Data;
using Alura.Data.DTOs.GerenteDTOs;
using Alura.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Services
{
    public class GerenteService
    {
        private IMapper _mapper;
        private FilmeContext _context;
        public GerenteService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<HeadGerenteDTO> ListarGerentes()
        {
            List<Gerente> gerentes = _context.Gerentes.ToList();
            if (gerentes == null)
            {
                return null;
            }
            return _mapper.Map<List<HeadGerenteDTO>>(gerentes);
        }

        public HeadGerenteDTO BuscarGerenteId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(x => x.GerenteId == id);
            if (gerente == null)
            {
                return null;
            }
            HeadGerenteDTO headGerenteDTO = _mapper.Map<HeadGerenteDTO>(gerente);
            return headGerenteDTO;
        }

        public HeadGerenteDTO AdicionarGerente(CreateGerenteDTO dto)
        {
            Gerente g = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(g);
            _context.SaveChanges();
            return _mapper.Map<HeadGerenteDTO>(g);
        }

        public Result AtualizarGerente(int id, UpdateGerenteDTO updateDto)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(x => x.GerenteId == id);
            if (gerente != null)
            {
                _mapper.Map(updateDto, gerente);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Gerente nao encontrado");
        }

        public Result DeletarGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(x => x.GerenteId == id);
            if (gerente != null)
            {
                _context.Gerentes.Remove(gerente);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Gerente nao encontrado");
        }
    }
}
