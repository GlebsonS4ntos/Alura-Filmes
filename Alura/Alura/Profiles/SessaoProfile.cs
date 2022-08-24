using Alura.Data.DTOs.SessaoDTOs;
using Alura.Models;
using AutoMapper;
using System.Linq;

namespace Alura.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDTO, Sessao>();
            CreateMap<Sessao, HeadSessaoDTO>()
                .ForMember(dto => dto.HarariodeInicioDaSessao, ops =>
                ops.MapFrom(dto => dto.HorariodeEncerramentoDaSessao.AddMinutes(dto.Filme.Duracao * (-1))));
            //ao fazer a multiplicação por -1, a função de adicionar minutos vai remover os minutos
            CreateMap<UpdateSessaoDTO, Gerente>();
        }
    }
}
