using Alura.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Alura.Data.DTOs.SessaoDTOs
{
    public class HeadSessaoDTO
    {
        public int SessaoId { get; set; }
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public DateTime HorariodeEncerramentoDaSessao { get; set; }
        public DateTime HarariodeInicioDaSessao { get; set; }
    }
}
