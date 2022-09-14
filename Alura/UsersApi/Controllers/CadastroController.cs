using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Dto;
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
            if (resultado.IsSuccess) return Ok();
            return StatusCode(500);
        }
    }
}
