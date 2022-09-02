using Alura.Data;
using Alura.Data.DTOs.CinemaDTOs;
using Alura.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Services
{
    public class CinemaService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public HeadCinemaDTO BuscarCinemaId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.CinemaId == id);
            if (cinema == null)
            {
                return null;
            }
            HeadCinemaDTO cinemaDto = _mapper.Map<HeadCinemaDTO>(cinema);
            return cinemaDto;
        }

        public List<HeadCinemaDTO> BuscarCinemas(string nomeFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if (cinemas == null) return null;
            if (!string.IsNullOrEmpty(nomeFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao =>
                                            sessao.Filme.FilmeName.ToUpper() == nomeFilme.ToUpper())
                                            select cinema;
                cinemas = query.ToList();
            }
            List<HeadCinemaDTO> headDTO = _mapper.Map<List<HeadCinemaDTO>>(cinemas);
            return headDTO;
        }

        public HeadCinemaDTO AdicionarCinema(CreatedCinemaDTO c)
        {
            Cinema cinema = _mapper.Map<Cinema>(c);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<HeadCinemaDTO>(cinema);
        }

        public Result AtualizarCinema(UpdateCinemaDTO c, int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.CinemaId == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado");
            }
            _mapper.Map(c, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarCinema(int id)
        {
            Cinema c = _context.Cinemas.FirstOrDefault(x => x.CinemaId == id);
            if (c == null)
            {
                return Result.Fail("Cinema não encontrado");
            }
            _context.Cinemas.Remove(c);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
