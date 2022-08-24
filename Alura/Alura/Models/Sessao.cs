using System;
using System.ComponentModel.DataAnnotations;

namespace Alura.Models
{
    public class Sessao
    {
        public int SessaoId { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        [Required(ErrorMessage = "O campo cinema é obrigatório !")]
        public int CinemaId { get; set; }
        [Required(ErrorMessage = "O campo Filme é obrigatório !")]
        public int FilmeId { get; set; }
        [Required(ErrorMessage = "O Horrario de Encerramento da sessão é obrigatorio !")]
        public DateTime HorariodeEncerramentoDaSessao { get; set; }
    }
}
