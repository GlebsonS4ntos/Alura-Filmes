using Alura.Data;
using Alura.Data.DTOs.SessaoDTOs;
using Alura.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Services
{
    public class SessaoService
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public SessaoService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<HeadSessaoDTO> TodasSessoes()
        {
            List<Sessao> sessoes = _context.Sessoes.ToList();
            if(sessoes == null)
            {
                return null;
            }
            return _mapper.Map<List<HeadSessaoDTO>>(sessoes);
        }

        public HeadSessaoDTO BuscarSessaoPorId(int id)
        {
            Sessao s = _context.Sessoes.FirstOrDefault(x => x.SessaoId == id);
            if (s == null)
            {
                return null;
            }
            HeadSessaoDTO headSessao = _mapper.Map<HeadSessaoDTO>(s);
            return _mapper.Map<HeadSessaoDTO>(headSessao);
        }

        public HeadSessaoDTO AdicionarSessao(CreateSessaoDTO sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<HeadSessaoDTO>(sessao);
        }

        public Result AtualizarSessao(int id, UpdateSessaoDTO updateDto)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(x => x.SessaoId == id);
            if (sessao != null)
            {
                _mapper.Map(updateDto, sessao);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Sessao nao encontrada");
        }

        public Result DeletarSessao(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(x => x.SessaoId == id);
            if (sessao != null)
            {
                _context.Sessoes.Remove(sessao);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Sessao nao encontrada");
        }
    }
}
