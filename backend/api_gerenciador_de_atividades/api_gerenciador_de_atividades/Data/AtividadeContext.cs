using api_gerenciador_de_atividades.Models;
using Microsoft.EntityFrameworkCore;

namespace api_gerenciador_de_atividades.Data;

public class AtividadeContext : DbContext
{
    public AtividadeContext(DbContextOptions<AtividadeContext> options) : base(options)
    {
    }

    public DbSet<Atividade> Atividades { get; set; }
}

