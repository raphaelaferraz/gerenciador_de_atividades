using AutoMapper;

namespace api_gerenciador_de_atividades.Profiles;

public class AtividadeProfile : Profile
{
    public AtividadeProfile()
    {
        CreateMap<Data.Dtos.CriarAtividadeDto, Models.Atividade>();
        CreateMap<Models.Atividade, Data.Dtos.LeituraAtividadeDto>();
    }
}
