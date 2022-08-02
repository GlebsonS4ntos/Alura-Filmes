using System;
using System.ComponentModel.DataAnnotations;

namespace Alura.Data.DTOs.CinemaDTOs
{
    public class UpdateCinemaDTO
    {
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [StringLength(50, ErrorMessage = "Nome com no maximo 50 caracteres")]
        public string CinemaName { get; set; }
    }
}
