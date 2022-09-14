﻿using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using UsersApi.Data.Requests;

namespace UsersApi.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LoginService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result Login(LoginRequest request)
        {
            var resultado = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultado.Result.Succeeded) return Result.Ok();
            return Result.Fail("Login Falhou");
        }
    }
}
