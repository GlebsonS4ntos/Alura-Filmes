using System.ComponentModel.DataAnnotations;

namespace UsersApi.Data.Requests
{
    public class SolicitaResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
