using HealthCare_API.Content.ProblemaSaude.ValueObject;
using HealthCare_API.Context;

namespace HealthCare_API.Content.ProblemaSaude.Interfaces;

public interface IProblemaSaudeRepository
{
    public ProblemaSaude.Entity.ProblemaSaude GetProblemaByID(int id);
    public IEnumerable<ProblemaSaude.Entity.ProblemaSaude> GetListProblemaSaude();

    public IEnumerable<ProblemaSaude.Entity.ProblemaSaude> GetListProblemaSaudeByGrauProblema(GrauEnum grau);

    public void AddProblema(ProblemaSaude.Entity.ProblemaSaude problema);
    public void EditProblema(ProblemaSaude.Entity.ProblemaSaude problema);
    public void DeleteProblema(int id);

}
