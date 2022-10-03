using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
            if(resultado.IsFailed) return Unauthorized(resultado.Errors.FirstOrDefault());
            return Ok(resultado.Successes.FirstOrDefault());
        }

        [HttpPost("/Solicitar-reset-senha")]
        public IActionResult SolicitaResetSenha(SolicitaResetRequest request)
        {
            Result resultado = _service.SolicitaResetSenha(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors.FirstOrDefault());
            return Ok(resultado.Successes.FirstOrDefault());
        }

        [HttpPost("/Efetua-reset-senha")]
        public IActionResult EfetuaResetSenha(EfetuaResetSenhaRequest request)
        {
            Result resultado = _service.EfetuaResetSenha(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors.FirstOrDefault());
            return Ok(resultado.Successes.FirstOrDefault());
        }
    }
}
