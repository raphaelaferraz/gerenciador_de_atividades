using System.ComponentModel.DataAnnotations;

namespace api_gerenciador_de_atividades.Data.Dtos;

public class CriarAtividadeDto
{
    [Required(ErrorMessage = "O nome da atividade é obrigatório!")]
    public string Nome { get; set; }
    [Required]
    public string Descricao { get; set; }
    [Required]
    public bool Concluida { get; set; }
}
