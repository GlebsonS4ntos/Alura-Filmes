﻿using Alura.Models;
using Microsoft.EntityFrameworkCore;

namespace Alura.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> otp) : base(otp){}

        public DbSet<Filme> Filmes { get; set; }
    }
}