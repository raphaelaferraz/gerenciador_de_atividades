using api_gerenciador_de_atividades.Data;
using api_gerenciador_de_atividades.Data.Dtos;
using api_gerenciador_de_atividades.Models;
using api_gerenciador_de_atividades.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_gerenciador_de_atividades.Controllers;

[Route("[controller]")]
[ApiController]
public class AtividadeController : ControllerBase
{
    /// <summary>
    /// Método privado para acesso ao serviço de atividade.
    /// </summary>
    private AtividadeService _atividadeService;

    /// <summary>
    /// Método privado para acesso ao mapeamento de atividade.
    /// </summary>
    private IMapper _mapper;

    public AtividadeController(IMapper mapper, AtividadeService atividadeService)
    {
        _atividadeService = atividadeService;
        _mapper = mapper;
    }


    /// <summary>
    /// Método POST para adicionar uma atividade no banco de dados.
    /// </summary>
    /// <param name="atividadeDto">Objeto da classe CriarAtividadeDTO</param>
    /// <returns>
    /// Retorna as informações da atividade criada.
    /// </returns>
    [HttpPost]
    public IActionResult AdicionaAtividade([FromBody] CriarAtividadeDto atividadeDto)
    {
        Atividade atividade = _mapper.Map<Atividade>(atividadeDto);
        _atividadeService.AddAtividade(atividade);
        return CreatedAtAction(nameof(RecuperaAtividadesPorId), new { id = atividade.Id }, atividade);
    }

    /// <summary>
    /// Método GET para recuperar todas as atividades cadastradas no banco de dados.
    /// </summary>
    /// <returns>
    /// Retorna as informações das atividades encontradas.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> RecuperaAtividadesAsync()
    {
        IEnumerable<LeituraAtividadeDto> atividades = await _atividadeService.GetAtividades();
        
        if (atividades == null)
        {
            return NotFound();
        }

        List<LeituraAtividadeDto> atividadesDto = _mapper.Map<List<LeituraAtividadeDto>>(atividades);

        return Ok(atividadesDto);
    }

    /// <summary>
    /// Método GET para recuperar uma atividade específica, a partir do seu ID.
    /// </summary>
    /// <param name="id">Identificar único da atividade</param>
    /// <returns>
    /// Retorna as informações da atividade encontrada.
    /// </returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> RecuperaAtividadesPorId(int id)
    {
        LeituraAtividadeDto atividadeDto = await _atividadeService.GetAtividadeById(id);
        if (atividadeDto != null)
        {
            return Ok(atividadeDto);
        }
        return NotFound();
    }

    /// <summary>
    /// Método PUT para atualizar uma atividade no banco de dados.
    /// </summary>
    /// <param name="id">Identificador único da atividade</param>
    /// <returns>
    /// Retorna as informações da atividade atualizada.
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizaAtividade(int id, [FromBody] AtualizarAtividadeDto atividadeDto)
    {
        LeituraAtividadeDto atividade = await _atividadeService.AtualizaAtividade(id, atividadeDto);
        if (atividade == null)
        {
            return NotFound();
        }
        return Ok(atividade);
    }

    /// <summary>
    /// Método DELETE para deletar uma atividade no banco de dados.
    /// </summary>
    /// <param name="id">Identificador único de atividade</param>
    /// <returns>
    /// Retorna as informações da atividade deletada.
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletaAtividade(int id)
    {
        LeituraAtividadeDto atividade = await _atividadeService.DeletaAtividade(id);
        if (atividade == null)
        {
            return NotFound();
        }
        return Ok(atividade);
    }
}
