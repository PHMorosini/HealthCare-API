using HealthCare_API.Content.ProblemaSaude.DTO;
using HealthCare_API.Content.ProblemaSaude.ValueObject;

namespace HealthCare_API.Content.ProblemaSaude.Interfaces;

public interface IProblemaSaudeService
{
    public ProblemaSaudeDTO GetProblemaByID(int id);
    public IEnumerable<ProblemaSaudeDTO> GetListProblemaSaude();

    public IEnumerable<ProblemaSaudeDTO> GetListProblemaSaudeByGrauProblema(GrauEnum grau);

    public void AddProblema(ProblemaSaudeDTO problema);
    public void EditProblema(ProblemaSaudeDTO problema);
    public void DeleteProblema(int id);
}
