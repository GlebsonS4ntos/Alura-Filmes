// <auto-generated />
using System;
using Alura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alura.Migrations
{
    [DbContext(typeof(FilmeContext))]
    partial class FilmeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alura.Models.Cinema", b =>
                {
                    b.Property<int>("CinemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CinemaName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("GerenteId")
                        .HasColumnType("int");

                    b.HasKey("CinemaId");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.HasIndex("GerenteId");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("Alura.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("EnderecoId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Alura.Models.Filme", b =>
                {
                    b.Property<int>("FilmeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassificacaoEtaria")
                        .HasColumnType("int");

                    b.Property<string>("Diretor")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<string>("FilmeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("FilmeId");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("Alura.Models.Gerente", b =>
                {
                    b.Property<int>("GerenteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GerenteName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GerenteId");

                    b.ToTable("Gerentes");
                });

            modelBuilder.Entity("Alura.Models.Sessao", b =>
                {
                    b.Property<int>("SessaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HorariodeEncerramentoDaSessao")
                        .HasColumnType("datetime2");

                    b.HasKey("SessaoId");

                    b.HasIndex("CinemaId");

                    b.HasIndex("FilmeId");

                    b.ToTable("Sessoes");
                });

            modelBuilder.Entity("Alura.Models.Cinema", b =>
                {
                    b.HasOne("Alura.Models.Endereco", "Endereco")
                        .WithOne("Cinema")
                        .HasForeignKey("Alura.Models.Cinema", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alura.Models.Gerente", "Gerente")
                        .WithMany("Cinemas")
                        .HasForeignKey("GerenteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Gerente");
                });

            modelBuilder.Entity("Alura.Models.Sessao", b =>
                {
                    b.HasOne("Alura.Models.Cinema", "Cinema")
                        .WithMany("Sessoes")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Alura.Models.Filme", "Filme")
                        .WithMany("Sessoes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("Alura.Models.Cinema", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("Alura.Models.Endereco", b =>
                {
                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("Alura.Models.Filme", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("Alura.Models.Gerente", b =>
                {
                    b.Navigation("Cinemas");
                });
#pragma warning restore 612, 618
        }
    }
}
