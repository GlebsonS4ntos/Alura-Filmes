using System.ComponentModel.DataAnnotations;

namespace UsersApi.Models
{
    public class Usuario
    {
        [Required]
        public int UsuarioId { get;set;}
        [Required]
        public string UserName { get;set;}
        [Required]
        public string Email { get; set; }
    }
}
