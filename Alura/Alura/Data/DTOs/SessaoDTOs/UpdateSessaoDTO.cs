using System.ComponentModel.DataAnnotations;
using System;

namespace Alura.Data.DTOs.SessaoDTOs
{
    public class UpdateSessaoDTO
    {
        [Required(ErrorMessage = "O campo cinema é obrigatório !")]
        public int CinemaId { get; set; }
        [Required(ErrorMessage = "O campo Filme é obrigatório !")]
        public int FilmeId { get; set; }
        [Required(ErrorMessage = "O Horrario de Encerramento da sessão é obrigatorio !")]
        public DateTime HorariodeEncerramentoDaSessao { get; set; }
    }
}
