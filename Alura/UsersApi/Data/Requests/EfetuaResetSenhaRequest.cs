using System.ComponentModel.DataAnnotations;

namespace UsersApi.Data.Requests
{
    public class EfetuaResetSenhaRequest
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CodigoDeRedefinicao { get;set; }
    }
}
