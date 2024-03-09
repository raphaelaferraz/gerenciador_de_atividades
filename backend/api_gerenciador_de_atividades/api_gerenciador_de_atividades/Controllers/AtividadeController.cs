using api_gerenciador_de_atividades.Data;
using api_gerenciador_de_atividades.Data.Dtos;
using api_gerenciador_de_atividades.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_gerenciador_de_atividades.Controllers;
[Route("[controller]")]
[ApiController]
public class AtividadeController : ControllerBase
{
    private AtividadeContext _contexto;

    private IMapper _mapper;

    public AtividadeController(AtividadeContext contexto, IMapper mapper)
    {
        _contexto = contexto;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaAtividade([FromBody] CriarAtividadeDto atividadeDto)
    {
        Atividade atividade = _mapper.Map<Atividade>(atividadeDto);
        _contexto.Atividades.Add(atividade);
        _contexto.SaveChanges();
        return CreatedAtAction(nameof(RecuperaAtividadesPorId), new { id = atividade.Id }, atividade);
    }

    [HttpGet]
    public IActionResult RecuperaAtividades()
    {
        List<Atividade> atividades = _contexto.Atividades.ToList();
        
        if (atividades.Count == 0)
        {
            return NoContent();
        }

        List<LeituraAtividadeDto> atividadesDto = _mapper.Map<List<LeituraAtividadeDto>>(atividades);

        return Ok(atividadesDto);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaAtividadesPorId(int id)
    {
        Atividade atividade = _contexto.Atividades.FirstOrDefault(atividade => atividade.Id == id);
        if (atividade != null)
        {
            LeituraAtividadeDto atividadeDto = _mapper.Map<LeituraAtividadeDto>(atividade);
            return Ok(atividadeDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaAtividade(int id, [FromBody] AtualizarAtividadeDto atividadeDto)
    {
        Atividade atividade = _contexto.Atividades.FirstOrDefault(atividade => atividade.Id == id);
        if (atividade == null)
        {
            return NotFound();
        }
        _mapper.Map(atividadeDto, atividade);
        _contexto.SaveChanges();
        return NoContent();
    }

}
