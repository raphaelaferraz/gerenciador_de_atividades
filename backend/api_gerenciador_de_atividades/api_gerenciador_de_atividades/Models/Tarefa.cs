﻿namespace api_gerenciador_de_atividades.Models;

public class Tarefa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool Concluida { get; set; }
}
