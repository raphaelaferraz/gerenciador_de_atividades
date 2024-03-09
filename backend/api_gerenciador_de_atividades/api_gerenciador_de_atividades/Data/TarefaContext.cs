using api_gerenciador_de_atividades.Models;
using Microsoft.EntityFrameworkCore;

namespace api_gerenciador_de_atividades.Data;

public class TarefaContext : DbContext
{
    public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
    {
    }

    public DbSet<Tarefa> Tarefas { get; set; }
}
