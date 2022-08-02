using System;
using System.ComponentModel.DataAnnotations;

namespace Alura.Data.DTOs.FilmeDTOs
{
    public class HeadFilmeDTO
    {
        [Key]
        [Required]
        public int FilmeId { get; set; }
        [Required(ErrorMessage = "Campo Nome é Obrigatorio")]
        public string FilmeName { get; set; }
        [StringLength(100, ErrorMessage = "O nome do diretor não deve ter mais que 100 caracteres")]
        public string Diretor { get; set; }
        [StringLength(20, ErrorMessage = "O genero não deve possuir mais que 20 caracteres")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "A duracao é obrigatoria")]
        [Range(1, 10, ErrorMessage = "A duração deve ser entre 1 a 10 horas.")]
        public int Duracao { get; set; }
        public DateTime DataConsulta { get; set; } = DateTime.Now;
    }
}
