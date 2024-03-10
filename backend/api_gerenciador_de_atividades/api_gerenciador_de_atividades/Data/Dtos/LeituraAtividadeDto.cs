namespace api_gerenciador_de_atividades.Data.Dtos;

/// <summary>
/// Classe responsável por ler uma atividade utilizando um DTO.
/// </summary>
public class LeituraAtividadeDto
{    
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool Concluida { get; set; }

    public LeituraAtividadeDto(int id, string nome, string descricao, bool concluida)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Concluida = concluida;
    }
}
