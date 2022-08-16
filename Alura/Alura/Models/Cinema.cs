using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Alura.Models;

namespace Alura.Models
{
    public class Cinema
    {
        public int CinemaId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [StringLength(50, ErrorMessage = "Nome com no maximo 50 caracteres")]
        public string CinemaName { get; set; }
        public virtual Endereco Endereco { get; set; }
        [Required]
        public int EnderecoId { get; set; }
        public virtual Gerente Gerente { get; set; }
        [Required]
        public int GerenteId { get; set; }
    }
}
