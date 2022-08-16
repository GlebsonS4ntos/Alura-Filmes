using Alura.Data.DTOs.GerenteDTOs;
using Alura.Models;
using AutoMapper;

namespace Alura.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDTO, Gerente>();
            CreateMap<Gerente, HeadGerenteDTO>();
            CreateMap<UpdateGerenteDTO, Gerente>();
        }
    }
}
