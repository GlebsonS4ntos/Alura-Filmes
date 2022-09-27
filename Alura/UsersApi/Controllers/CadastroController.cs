using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsersApi.Data.Dto;
using UsersApi.Data.Requests;
using UsersApi.Services;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private UsuarioService _service;

        public CadastroController(UsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CadatroUsuario([FromBody] CreateUsuarioDto dto)
        {
            Result resultado = _service.AdicionarUsuario(dto);
            if (resultado.IsSuccess) return Ok(resultado.Successes.FirstOrDefault());
            return StatusCode(500);
        }

        [HttpGet("/Ativacao")]
        public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request)
        {
            Result resultado = _service.AtivaContaUsuario(request);
            if (resultado.IsSuccess) return Ok();
            return StatusCode(500);
        }
    }
}
