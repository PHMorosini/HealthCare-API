using AutoMapper;
using HealthCare_API.Content.ProblemaSaude.DTO;
using ProblemaSaudeEntity = HealthCare_API.Content.ProblemaSaude.Entity.ProblemaSaude;

namespace HealthCare_API.Mappers;

public class ProblemaSaudeProfile : Profile
{
    public ProblemaSaudeProfile()
    {
        CreateMap<ProblemaSaudeEntity, ProblemaSaudeDTO>(); 
        CreateMap<ProblemaSaudeDTO, ProblemaSaudeEntity>(); 
    }
}
