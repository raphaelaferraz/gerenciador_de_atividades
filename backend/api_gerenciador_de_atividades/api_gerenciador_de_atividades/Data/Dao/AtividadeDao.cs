using api_gerenciador_de_atividades.Models;
using Microsoft.EntityFrameworkCore;

namespace api_gerenciador_de_atividades.Data.Dao;

public class AtividadeDao
{
    private readonly AtividadeContext _context;

    public AtividadeDao(AtividadeContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Atividade>> GetAtividades()
    {
        return await _context.Atividades.ToListAsync();
    }

    public async Task<Atividade> GetAtividadeById(int id)
    {
        return await _context.Atividades.FirstOrDefaultAsync(atividade => atividade.Id == id);
    }

    public async Task<Atividade> AddAtividade(Atividade atividade)
    {
        _context.Atividades.Add(atividade);
        await _context.SaveChangesAsync();
        return atividade;
    }
}
