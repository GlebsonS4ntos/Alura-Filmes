using System.ComponentModel.DataAnnotations;

namespace Alura.Models
{
    public class Cinema
    {
        public int CinemaId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [StringLength(50, ErrorMessage = "Nome com no maximo 50 caracteres")]
        public string CinemaName { get; set; }
    }
}
