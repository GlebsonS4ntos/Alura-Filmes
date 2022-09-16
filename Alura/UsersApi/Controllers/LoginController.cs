﻿using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Requests;
using UsersApi.Services;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _service;

        public LoginController(LoginService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            Result resultado = _service.Login(request);
            if(resultado.IsFailed) return Unauthorized();
            return Ok();
        }
    }
}