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
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login Falhou");
        }
    }
}
