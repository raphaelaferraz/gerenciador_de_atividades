namespace api_gerenciador_de_atividades.Data.Dtos;

/// <summary>
/// Classe responsável por ler uma atividade utilizando um DTO.
/// </summary>
public class LeituraAtividadeDto
{    
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool Concluida { get; set; }

    public LeituraAtividadeDto(string nome, string descricao, bool concluida)
    {
        Nome = nome;
        Descricao = descricao;
        Concluida = concluida;
    }
}
