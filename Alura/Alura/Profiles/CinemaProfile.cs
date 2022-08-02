using Alura.Data.DTOs.CinemaDTOs;
using Alura.Models;
using AutoMapper;

namespace Alura.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreatedCinemaDTO, Cinema>();
            CreateMap<Cinema, HeadCinemaDTO>();
            CreateMap<UpdateCinemaDTO, Cinema>(); 
        }
    }
}
