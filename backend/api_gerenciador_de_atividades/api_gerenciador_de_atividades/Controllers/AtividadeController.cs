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
    private AtividadeService _atividadeService;

    private IMapper _mapper;

    public AtividadeController(IMapper mapper, AtividadeService atividadeService)
    {
        _atividadeService = atividadeService;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaAtividade([FromBody] CriarAtividadeDto atividadeDto)
    {
        Atividade atividade = _mapper.Map<Atividade>(atividadeDto);
        _atividadeService.AddAtividade(atividade);
        return CreatedAtAction(nameof(RecuperaAtividadesPorId), new { id = atividade.Id }, atividade);
    }

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
