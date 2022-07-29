using Alura.Data.DTOs;
using Alura.Models;
using AutoMapper;

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
