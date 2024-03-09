using api_gerenciador_de_atividades.Models;
using Microsoft.EntityFrameworkCore;

namespace api_gerenciador_de_atividades.Data.Dao;

public class AtividadeDao
{
    /// <summary>
    /// Atributo privado para acesso ao contexto de banco de dados de atividade.
    /// </summary>
    private readonly AtividadeContext _context;

    public AtividadeDao(AtividadeContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Método para recuperar todas as atividades cadastradas no banco de dados.
    /// </summary>
    /// <returns>
    /// Retorna uma lista de atividades encontradas no banco de dados.
    /// </returns>
    public async Task<IEnumerable<Atividade>> GetAtividades()
    {
        return await _context.Atividades.ToListAsync();
    }

    /// <summary>
    /// Método para recuperar uma atividade específica, a partir do seu ID.
    /// </summary>
    /// <param name="id">Identificador único da atividade</param>
    /// <returns>
    /// Lista de atividades encontradas no banco de dados.
    /// </returns>
    public async Task<Atividade> GetAtividadeById(int id)
    {
        return await _context.Atividades.FirstOrDefaultAsync(atividade => atividade.Id == id);
    }

    /// <summary>
    /// Método para criar uma atividade no banco de dados.
    /// </summary>
    /// <param name="atividade">Objeto da classe Atividade</param>
    /// <returns>
    /// Retorna as informações da atividade criada.
    /// </returns>
    public async Task<Atividade> AddAtividade(Atividade atividade)
    {
        _context.Atividades.Add(atividade);
        await _context.SaveChangesAsync();
        return atividade;
    }

    /// <summary>
    /// Método para atualizar uma atividade no banco de dados.
    /// </summary>
    /// <param name="atividade">Objeto da classe Atividade</param>
    /// <returns>
    /// Retorna as informações da atividade atualizada.
    /// </returns>
    public async Task<Atividade> AtualizaAtividade(Atividade atividade)
    {
        _context.Atividades.Update(atividade);
        await _context.SaveChangesAsync();
        return atividade;
    }

    /// <summary>
    /// Método para deletar uma atividade no banco de dados.
    /// </summary>
    /// <param name="id">Identificar único de atividade</param>
    /// <returns>
    /// Retorna as informações da atividade deletada.
    /// </returns>
    public async Task<Atividade> DeletaAtividade(int id)
    {
        var atividade = await GetAtividadeById(id);
        _context.Atividades.Remove(atividade);
        await _context.SaveChangesAsync();
        return atividade;
    }
}
