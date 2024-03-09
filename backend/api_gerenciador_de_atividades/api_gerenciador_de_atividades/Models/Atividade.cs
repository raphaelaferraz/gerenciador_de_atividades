﻿namespace api_gerenciador_de_atividades.Models;

/// <summary>
/// Classe que representa uma atividade.
/// </summary>
public class Atividade
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool Concluida { get; set; }
}
