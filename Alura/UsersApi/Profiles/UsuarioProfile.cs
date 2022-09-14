using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Dto;
using UsersApi.Models;

namespace UsersApi.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}
