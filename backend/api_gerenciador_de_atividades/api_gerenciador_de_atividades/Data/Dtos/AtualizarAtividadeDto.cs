using System.ComponentModel.DataAnnotations;

namespace api_gerenciador_de_atividades.Data.Dtos;

public class AtualizarAtividadeDto
{
    [Required(ErrorMessage = "O nome da atividade é obrigatório!")]
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool Concluida { get; set; }
}
