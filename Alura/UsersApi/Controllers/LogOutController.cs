using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsersApi.Services;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogOutController : ControllerBase
    {
        private LogOutService _logOutService;

        public LogOutController(LogOutService logOutService)
        {
            _logOutService = logOutService;
        }

        [HttpPost]
        public IActionResult LogOutUser()
        {
            Result resultado = _logOutService.LogOut();
            if (resultado.IsFailed) return Unauthorized(resultado.Errors.FirstOrDefault());
            return Ok(resultado.Successes.FirstOrDefault());
        }
    }
}
