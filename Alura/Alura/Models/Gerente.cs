using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Alura.Models
{
    public class Gerente
    {
        public int GerenteId { get; set; }
        [Required(ErrorMessage = "Campo nome requerido")]
        [StringLength(50, ErrorMessage = "Tamanho maximo do nome de 50 caracteres")]
        public string GerenteName { get; set; }
        [Required(ErrorMessage = "Campo CPF Obrigatorio !!")]
        public string CPF { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cinema> Cinemas { get; set; } 
    }
}
