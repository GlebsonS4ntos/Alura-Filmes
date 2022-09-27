using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsersApi.Data.Dto;
using UsersApi.Data.Requests;
using UsersApi.Models;

namespace UsersApi.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;

        public UsuarioService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result AdicionarUsuario(CreateUsuarioDto dto)
        {
            Usuario user = _mapper.Map<Usuario>(dto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> resultado = _userManager.CreateAsync(userIdentity, dto.Password);
            if (resultado.Result.Succeeded) 
            {
                string codigo = _userManager.GenerateEmailConfirmationTokenAsync(userIdentity).Result;
                string encode = HttpUtility.UrlEncode(codigo); // O encode vai evitar que ao passar como parametro
                                                               // na url de ativação algum caracter mude
                _emailService.EnviarEmail(new[] { userIdentity.Email} , "Link de Ativacao da Conta", 
                                            userIdentity.Id, encode);
                return Result.Ok().WithSuccess(encode); 
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
