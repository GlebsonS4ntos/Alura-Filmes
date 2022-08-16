using Alura.Data.DTOs.GerenteDTOs;
using Alura.Models;
using AutoMapper;
using System.Linq;

namespace Alura.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDTO, Gerente>();
            CreateMap<Gerente, HeadGerenteDTO>()
                .ForMember(gerente => gerente.Cinemas, opcoes => opcoes
                .MapFrom(gerente => gerente.Cinemas
                .Select(c => new { c.CinemaId, c.CinemaName, c.Endereco, c.EnderecoId})));
            //A forma acima é uma forma de acabar com a vinda de informações sobre o gerente dentro da consulta de um gerente evitando assim ciclos
            CreateMap<UpdateGerenteDTO, Gerente>();
        }
    }
}
