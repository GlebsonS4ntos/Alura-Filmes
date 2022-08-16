using System;
using System.ComponentModel.DataAnnotations;

namespace Alura.Data.DTOs.CinemaDTOs
{
    public class UpdateCinemaDTO
    {
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [StringLength(50, ErrorMessage = "Nome com no maximo 50 caracteres")]
        public string CinemaName { get; set; }
        [Required(ErrorMessage = "Campo Endereco é obrigatorio")]
        public int EnderecoId { get; set; }
        [Required(ErrorMessage = "Campo Gerente é obrigatorio")]
        public int GerenteId { get; set; }
    }
}
