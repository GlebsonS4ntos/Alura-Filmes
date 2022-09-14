using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using UsersApi.Data.Dto;
using UsersApi.Models;

namespace UsersApi.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;

        public UsuarioService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result AdicionarUsuario(CreateUsuarioDto dto)
        {
            Usuario user = _mapper.Map<Usuario>(dto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> resultado = _userManager.CreateAsync(userIdentity, dto.Password);
            if (resultado.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuario");
        }
    }
}
