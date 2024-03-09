using System.ComponentModel.DataAnnotations;

namespace api_gerenciador_de_atividades.Data.Dtos;

/// <summary>
/// Classe responsável por atualizar uma atividade utilizando um DTO.
/// </summary>
/// <remarks>
/// Atributos: nome, descrição e concluída
/// </remarks>
public class AtualizarAtividadeDto
{
    [Required(ErrorMessage = "O nome da atividade é obrigatório!")]
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool Concluida { get; set; }
}
