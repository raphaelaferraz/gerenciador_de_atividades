using api_gerenciador_de_atividades.Data.Dao;
using api_gerenciador_de_atividades.Data.Dtos;
using api_gerenciador_de_atividades.Models;

namespace api_gerenciador_de_atividades.Services;

public class AtividadeService
{
    private readonly AtividadeDao _atividadeDao;

    public AtividadeService(AtividadeDao atividadeDao)
    {
        _atividadeDao = atividadeDao;
    }

    public async Task<IEnumerable<LeituraAtividadeDto>> GetAtividades()
    {
        var atividades = await _atividadeDao.GetAtividades();
        return atividades.Select(atividade => new LeituraAtividadeDto(atividade.Nome, atividade.Descricao, atividade.Concluida));
    }

    public async Task<LeituraAtividadeDto> GetAtividadeById(int id)
    {
        var atividade = await _atividadeDao.GetAtividadeById(id);
        return new LeituraAtividadeDto(atividade.Nome, atividade.Descricao, atividade.Concluida);
    }

    public async Task<LeituraAtividadeDto> AddAtividade(CriarAtividadeDto atividadeDto)
    {
        var atividade = new Atividade
        {
            Nome = atividadeDto.Nome,
            Descricao = atividadeDto.Descricao,
            Concluida = atividadeDto.Concluida
        };
        await _atividadeDao.AddAtividade(atividade);
        return new LeituraAtividadeDto(atividade.Nome, atividade.Descricao, atividade.Concluida);
    }
}
