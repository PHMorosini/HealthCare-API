using AutoMapper;
using HealthCare_API.Content.Cliente.DTO;
using HealthCare_API.Content.ProblemaSaude.DTO;
using HealthCare_API.Content.ProblemaSaude.Interfaces;
using HealthCare_API.Content.ProblemaSaude.ValueObject;
using ProblemaSaudeEntity = HealthCare_API.Content.ProblemaSaude.Entity.ProblemaSaude;

namespace HealthCare_API.Content.ProblemaSaude.Services;

public class ProblemaSaudeService : IProblemaSaudeService
{
    private readonly IProblemaSaudeRepository _repository;
    private readonly IMapper _mapper;

    public ProblemaSaudeService(IProblemaSaudeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }

    public void AddProblema(ProblemaSaudeDTO problemadto)
    {
        var problema = _mapper.Map<ProblemaSaudeEntity>(problemadto);
        _repository.AddProblema(problema);
    }

    public void DeleteProblema(int id)
    {
        _repository.DeleteProblema(id);
    }

    public void EditProblema(ProblemaSaudeDTO problemadto)
    {
        var problema = _mapper.Map<ProblemaSaudeEntity>(problemadto);
        _repository.EditProblema(problema);
    }

    public IEnumerable<ProblemaSaudeDTO> GetListProblemaSaude()
    {
        IEnumerable<ProblemaSaudeEntity> listproblema = _repository.GetListProblemaSaude();
        IEnumerable<ProblemaSaudeDTO> problemasdto = listproblema.Select(problema => new ProblemaSaudeDTO
        {
            Id = problema.Id,
            Nome = problema.Nome,
            Grau = problema.Grau
        });
        return problemasdto;
    }

    public IEnumerable<ProblemaSaudeDTO> GetListProblemaSaudeByGrauProblema(GrauEnum grau)
    {
        IEnumerable<ProblemaSaudeEntity> listaproblema = _repository.GetListProblemaSaudeByGrauProblema(grau);
        IEnumerable<ProblemaSaudeDTO> problemasdto = listaproblema.Select(problema => new ProblemaSaudeDTO
        {
            Id = problema.Id,
            Nome = problema.Nome,
            Grau = problema.Grau
        });
        return problemasdto;
    }

    public ProblemaSaudeDTO GetProblemaByID(int id)
    {
        var problema = _repository.GetProblemaByID(id);
        var problemadto = _mapper.Map<ProblemaSaudeDTO>(problema);
        return problemadto;

    }
}
