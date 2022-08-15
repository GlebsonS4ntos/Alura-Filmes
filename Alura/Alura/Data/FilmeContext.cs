using Alura.Models;
using Microsoft.EntityFrameworkCore;

namespace Alura.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> otp) : base(otp){}

        protected override void OnModelCreating( ModelBuilder builder)
        {
            builder.Entity<Endereco>().HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco).HasForeignKey<Cinema>(cinema => cinema.EnderecoId);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
