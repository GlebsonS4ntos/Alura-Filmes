using System;
using System.ComponentModel.DataAnnotations;

namespace Alura.Data.DTOs.EnderecoDTOs
{
    public class HeadEnderecoDTO
    {
        [Key]
        [Required]
        public int EnderecoId { get; set; }
        [Required(ErrorMessage = "Campo Logradouro é Obrigatorio !")]
        [StringLength(50, ErrorMessage = "O Logradouro não pode ter mais que 50 caracteres")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Campo Bairro é Obrigatorio !")]
        [StringLength(50, ErrorMessage = "O Bairro não pode ter mais que 50 caracteres")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Campo Numero é Obrigatorio !")]
        public int Numero { get; set; }
        public DateTime DataConsulta { get; set; } = DateTime.Now;
    }
}
