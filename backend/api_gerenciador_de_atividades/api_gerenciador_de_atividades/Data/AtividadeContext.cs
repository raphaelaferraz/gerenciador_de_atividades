﻿using api_gerenciador_de_atividades.Models;
using Microsoft.EntityFrameworkCore;

namespace api_gerenciador_de_atividades.Data;

/// <summary>
/// Classe responsável por representar o contexto do banco de dados.
/// </summary>
public class AtividadeContext : DbContext
{
    public AtividadeContext(DbContextOptions<AtividadeContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atividade>().ToTable("Atividades");
    }

    public DbSet<Atividade> Atividades { get; set; }
}

