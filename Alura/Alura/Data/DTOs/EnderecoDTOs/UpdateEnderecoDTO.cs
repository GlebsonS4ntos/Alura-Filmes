using System.ComponentModel.DataAnnotations;

namespace Alura.Data.DTOs.EnderecoDTOs
{
    public class UpdateEnderecoDTO
    {
        [Required(ErrorMessage = "Campo Logradouro é Obrigatorio !")]
        [StringLength(50, ErrorMessage = "O Logradouro não pode ter mais que 50 caracteres")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Campo Bairro é Obrigatorio !")]
        [StringLength(50, ErrorMessage = "O Bairro não pode ter mais que 50 caracteres")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Campo Numero é Obrigatorio !")]
        public int Numero { get; set; }
    }
}
