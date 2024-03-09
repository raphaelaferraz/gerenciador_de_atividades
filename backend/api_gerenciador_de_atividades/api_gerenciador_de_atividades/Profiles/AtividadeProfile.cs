using AutoMapper;

namespace api_gerenciador_de_atividades.Profiles;

/// <summary>
/// Classe responsável por mapear os objetos da classe Atividade.
/// </summary>
public class AtividadeProfile : Profile
{
    public AtividadeProfile()
    {
        CreateMap<Data.Dtos.CriarAtividadeDto, Models.Atividade>();
        CreateMap<Models.Atividade, Data.Dtos.LeituraAtividadeDto>();
        CreateMap<Data.Dtos.AtualizarAtividadeDto, Models.Atividade>();
    }
}
