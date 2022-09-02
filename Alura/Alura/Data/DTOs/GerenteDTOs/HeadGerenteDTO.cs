using Alura.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alura.Data.DTOs.GerenteDTOs
{
    public class HeadGerenteDTO
    {
        public int GerenteId { get; set; }
        [Required(ErrorMessage = "Campo nome requerido")]
        [StringLength(50, ErrorMessage = "Tamanho maximo do nome de 50 caracteres")]
        public string GerenteName { get; set; }
        [Required(ErrorMessage = "Campo CPF Obrigatorio !!")]
        public string CPF { get; set; }
        public object Cinemas { get; set; }
        public DateTime DataConsulta { get; set; } = DateTime.Now;
    }
}
