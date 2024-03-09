using api_gerenciador_de_atividades.Data;
using api_gerenciador_de_atividades.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_gerenciador_de_atividades.Controllers;
[Route("[controller]")]
[ApiController]
public class AtividadeController : ControllerBase
{
    private AtividadeContext _contexto;

    public AtividadeController(AtividadeContext contexto)
    {
        _contexto = contexto;
    }

    [HttpPost]
    public IActionResult AdicionaAtividade([FromBody] Atividade atividade)
    {
        _contexto.Atividades.Add(atividade);
        _contexto.SaveChanges();
        return CreatedAtAction(nameof(RecuperaAtividadesPorId), new { nome = atividade.Nome }, atividade);
    }

    [HttpGet]
    public IEnumerable<Atividade> RecuperaAtividades()
    {
        return _contexto.Atividades;
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaAtividadesPorId(int id)
    {
        Atividade atividade = _contexto.Atividades.FirstOrDefault(atividade => atividade.Id == id);
        if (atividade != null)
        {
            return Ok(atividade);
        }
        return NotFound();
    }
}
