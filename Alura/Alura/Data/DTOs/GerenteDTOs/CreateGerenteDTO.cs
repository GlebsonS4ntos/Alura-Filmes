using System.ComponentModel.DataAnnotations;

namespace Alura.Data.DTOs.GerenteDTOs
{
    public class CreateGerenteDTO
    {
        [Required(ErrorMessage = "Campo nome requerido")]
        [StringLength(50, ErrorMessage = "Tamanho maximo do nome de 50 caracteres")]
        public string GerenteName { get; set; }
        [Required(ErrorMessage = "Campo CPF Obrigatorio !!")]
        public string CPF { get; set; }
    }
}
