using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Data.Dto;
using UsersApi.Data.Requests;
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
            if (resultado.Result.Succeeded) 
            {
                string codigo = _userManager.GenerateEmailConfirmationTokenAsync(userIdentity).Result;
                return Result.Ok().WithSuccess(codigo); 
            }
            return Result.Fail("Falha ao cadastrar usuario");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            IdentityUser<int> userIdentity = _userManager.Users.FirstOrDefault(u => u.Id == request.UsuarioId);
            var resultado = _userManager.ConfirmEmailAsync(userIdentity, request.CodigoDeAtivacao).Result;
            if(resultado.Succeeded) return Result.Ok();
            return Result.Fail("Erro ao ativar a conta");
        }
    }
}
