using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Alura.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        [Required(ErrorMessage = "Campo Logradouro é Obrigatorio !")]
        [StringLength(50, ErrorMessage = "O Logradouro não pode ter mais que 50 caracteres")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Campo Bairro é Obrigatorio !")]
        [StringLength(50, ErrorMessage = "O Bairro não pode ter mais que 50 caracteres")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Campo Numero é Obrigatorio !")]
        public int Numero { get; set; }
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
