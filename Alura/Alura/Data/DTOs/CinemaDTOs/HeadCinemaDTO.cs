using Alura.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alura.Data.DTOs.CinemaDTOs
{
    public class HeadCinemaDTO
    {
        [Key]
        [Required]
        public int CinemaId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [StringLength(50, ErrorMessage = "Nome com no maximo 50 caracteres")]
        public string CinemaName { get; set; }
        public Endereco Endereco { get; set;}
        public Gerente Gerente { get; set; }
        public ICollection<Sessao> Sessoes { get; set; }
        public DateTime DataConsulta { get; set; } = DateTime.Now;
    }
}
