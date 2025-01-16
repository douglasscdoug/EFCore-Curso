﻿// <auto-generated />
using FuscaFilmes.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FuscaFilmes.API.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("FuscaFilmes.API.Entities.Diretor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Diretores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Christopher Nolan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Quentin Tarantino"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Steven Spielberg"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Martin Scorsese"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Ridley Scott"
                        });
                });

            modelBuilder.Entity("FuscaFilmes.API.Entities.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiretorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DiretorId");

                    b.ToTable("Filmes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ano = 2010,
                            DiretorId = 1,
                            Titulo = "Inception"
                        },
                        new
                        {
                            Id = 2,
                            Ano = 2008,
                            DiretorId = 1,
                            Titulo = "The Dark Knight"
                        },
                        new
                        {
                            Id = 3,
                            Ano = 1994,
                            DiretorId = 2,
                            Titulo = "Pulp Fiction"
                        },
                        new
                        {
                            Id = 4,
                            Ano = 2003,
                            DiretorId = 2,
                            Titulo = "Kill Bill: Vol. 1"
                        },
                        new
                        {
                            Id = 5,
                            Ano = 1993,
                            DiretorId = 3,
                            Titulo = "Schindler's List"
                        },
                        new
                        {
                            Id = 6,
                            Ano = 1993,
                            DiretorId = 3,
                            Titulo = "Jurassic Park"
                        },
                        new
                        {
                            Id = 7,
                            Ano = 1976,
                            DiretorId = 4,
                            Titulo = "Taxi Driver"
                        },
                        new
                        {
                            Id = 8,
                            Ano = 1990,
                            DiretorId = 4,
                            Titulo = "Goodfellas"
                        },
                        new
                        {
                            Id = 9,
                            Ano = 2000,
                            DiretorId = 5,
                            Titulo = "Gladiator"
                        },
                        new
                        {
                            Id = 10,
                            Ano = 1979,
                            DiretorId = 5,
                            Titulo = "Alien"
                        });
                });

            modelBuilder.Entity("FuscaFilmes.API.Entities.Filme", b =>
                {
                    b.HasOne("FuscaFilmes.API.Entities.Diretor", "Diretor")
                        .WithMany("Filmes")
                        .HasForeignKey("DiretorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diretor");
                });

            modelBuilder.Entity("FuscaFilmes.API.Entities.Diretor", b =>
                {
                    b.Navigation("Filmes");
                });
#pragma warning restore 612, 618
        }
    }
}
