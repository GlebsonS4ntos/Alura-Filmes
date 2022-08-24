using Alura.Data.DTOs.FilmeDTOs;
using Alura.Models;
using AutoMapper;
using System.Linq;

namespace Alura.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<Filme, HeadFilmeDTO>();
            CreateMap<UpdateFilmeDTO, Filme>();
        } 
    }
}
