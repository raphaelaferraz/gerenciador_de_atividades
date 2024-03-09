using api_gerenciador_de_atividades.Data.Dao;
using api_gerenciador_de_atividades.Data.Dtos;
using api_gerenciador_de_atividades.Models;

namespace api_gerenciador_de_atividades.Services;

public class AtividadeService
{
    /// <summary>
    /// Atributo privado para acesso ao DAO de atividade.
    /// </summary>
    private readonly AtividadeDao _atividadeDao;

    public AtividadeService(AtividadeDao atividadeDao)
    {
        _atividadeDao = atividadeDao;
    }

    /// <summary>
    /// Método para recuperar todas as atividades cadastradas no banco de dados.
    /// </summary>
    /// <permission cref="HttpGet">Método HTTP GET</permission>"
    /// <returns>
    /// Lista de atividades, a partir do DTO, encontradas no banco de dados.
    /// </returns>
    public async Task<IEnumerable<LeituraAtividadeDto>> GetAtividades()
    {
        var atividades = await _atividadeDao.GetAtividades();
        return atividades.Select(atividade => new LeituraAtividadeDto(atividade.Nome, atividade.Descricao, atividade.Concluida));
    }

    /// <summary>
    /// Método para recuperar uma atividade específica, a partir do seu ID.
    /// </summary>
    /// <param name="id">Identificador único da atividade</param>
    /// <returns>
    /// Lista de atividades, a partir do DTO, encontradas no banco de dados.
    /// </returns>
    public async Task<LeituraAtividadeDto> GetAtividadeById(int id)
    {
        var atividade = await _atividadeDao.GetAtividadeById(id);
        return new LeituraAtividadeDto(atividade.Nome, atividade.Descricao, atividade.Concluida);
    }

    /// <summary>
    /// Método para criar uma atividade no banco de dados. 
    /// </summary>
    /// <param name="atividade">Objeto da classe Atividade</param>
    /// <returns>
    /// Retorna as informações da atividade criada.
    /// </returns>
    public async Task<LeituraAtividadeDto> AddAtividade(Atividade atividade)
    {
        await _atividadeDao.AddAtividade(atividade);
        return new LeituraAtividadeDto(atividade.Nome, atividade.Descricao, atividade.Concluida);
    }

    /// <summary>
    /// Método para atualizar uma atividade no banco de dados.
    /// </summary>
    /// <param name="id">Identificador único da atividade</param>
    /// <param name="atividadeDto">Objeto da classe AtividadeDto</param>
    /// <returns>
    /// Retorna as informações da atividade atualizada.
    /// </returns>
    public async Task<LeituraAtividadeDto> AtualizaAtividade(int id, AtualizarAtividadeDto atividadeDto)
    {
        var atividade = await _atividadeDao.GetAtividadeById(id);
        atividade.Nome = atividadeDto.Nome;
        atividade.Descricao = atividadeDto.Descricao;
        atividade.Concluida = atividadeDto.Concluida;
        await _atividadeDao.AtualizaAtividade(atividade);
        return new LeituraAtividadeDto(atividade.Nome, atividade.Descricao, atividade.Concluida);
    }

    /// <summary>
    /// Método para deletar uma atividade no banco de dados.
    /// </summary>
    /// <param name="id">Identificador único da atividade</param>
    /// <returns>
    /// Retorna as informações da atividade deletada.
    /// </returns>
    public async Task<LeituraAtividadeDto> DeletaAtividade(int id)
    {
        var atividade = await _atividadeDao.DeletaAtividade(id);
        return new LeituraAtividadeDto(atividade.Nome, atividade.Descricao, atividade.Concluida);
    }
}
