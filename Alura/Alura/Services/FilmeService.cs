using Alura.Data;
using Alura.Data.DTOs.FilmeDTOs;
using Alura.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Services
{
    public class FilmeService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public HeadFilmeDTO AdicionarFilme(CreateFilmeDTO filmeDTO)
        {
            Filme filme = _mapper.Map<Filme>(filmeDTO);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<HeadFilmeDTO>(filme);
        }

        public List<HeadFilmeDTO> ListarFilme(int? classificacaoIndicativa)
        {
            List<Filme> filmes;
            if (classificacaoIndicativa == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(x => x.ClassificacaoEtaria <= classificacaoIndicativa).ToList();
            }

            if (filmes != null)
            {
                List<HeadFilmeDTO> headDto = _mapper.Map<List<HeadFilmeDTO>>(filmes);
                return headDto;
            }
            return null;
        }

        public HeadFilmeDTO BuscarFilmePorId(int id)
        {
            Filme f = _context.Filmes.FirstOrDefault(x => x.FilmeId == id);
            if (f != null)
            {
                HeadFilmeDTO filmeDTO = _mapper.Map<HeadFilmeDTO>(f);
                return filmeDTO;
            }
            return null;
        }

        public Result AtualizarFilme(UpdateFilmeDTO filmeDTO, int id)
        {
            Filme f = _context.Filmes.FirstOrDefault(x => x.FilmeId == id);
            if (f == null)
            {
                return Result.Fail("Filme nao encontrado"); //retorna false caso não tenha filme correspondente ao Id informado
            }
            _mapper.Map(filmeDTO, f);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result RemoverFilme(int id)
        {
            Filme f = _context.Filmes.FirstOrDefault(x => x.FilmeId == id);
            if (f == null)
            {
                return Result.Fail("Filme nao encontrado");
            }
            _context.Filmes.Remove(f);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
