using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsersApi.Data.Requests;
using UsersApi.Models;

namespace UsersApi.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result Login(LoginRequest request)
        {
            var resultado = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultado.Result.Succeeded)
            {
                IdentityUser<int> identityUser = _signInManager.UserManager.Users
                                        .FirstOrDefault(x => x.NormalizedUserName == request.UserName.ToUpper());
                Token token = _tokenService.CreateToken(identityUser, 
                                            _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login Falhou");
        }

        public Result SolicitaResetSenha(SolicitaResetRequest request)
        {
            IdentityUser<int> user = BuscaUsuarioPorEmail(request.Email);
            if (user != null)
            {
                string codigoDeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(user).Result;
                return Result.Ok().WithSuccess(codigoDeRecuperacao);
            }
            return Result.Fail("Erro ao Solicitar a Mudança de Senha");
        }

        public Result EfetuaResetSenha(EfetuaResetSenhaRequest request)
        {
            IdentityUser<int> user = BuscaUsuarioPorEmail(request.Email);
            IdentityResult resultado = _signInManager.UserManager.ResetPasswordAsync(user,
                                        request.CodigoDeRedefinicao, request.Password).Result;
            if (resultado.Succeeded) return Result.Ok().WithSuccess("Senha Redefinida com sucesso");
            return Result.Fail("Falha ao Redefinir a Senha");
        }

        private IdentityUser<int> BuscaUsuarioPorEmail(string email)
        {
            return _signInManager.UserManager.Users
                            .FirstOrDefault(x => x.NormalizedEmail == email.ToUpper());
        }
    }
}
