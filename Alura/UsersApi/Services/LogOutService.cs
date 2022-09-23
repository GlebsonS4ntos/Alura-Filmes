using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;

namespace UsersApi.Services
{
    public class LogOutService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogOutService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogOut()
        {
            var deslogar = _signInManager.SignOutAsync();
            if (deslogar.IsCompletedSuccessfully) return Result.Ok().WithSuccess("Usuario deslogado");
            return Result.Fail("Erro ao Deslogar");
        }
    }
}
