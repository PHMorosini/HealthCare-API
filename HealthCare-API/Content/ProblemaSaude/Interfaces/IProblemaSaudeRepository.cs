using HealthCare_API.Content.ProblemaSaude.ValueObject;
using HealthCare_API.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthCare_API.Content.ProblemaSaude.Interfaces;

public interface IProblemaSaudeRepository
{
    public ProblemaSaude.Entity.ProblemaSaude GetProblemaByID(int id);
    public IEnumerable<ProblemaSaude.Entity.ProblemaSaude> GetListProblemaSaude();

    public IEnumerable<ProblemaSaude.Entity.ProblemaSaude> GetListProblemaSaudeByGrauProblema(GrauEnum grau);

    public void AddProblema(ProblemaSaude.Entity.ProblemaSaude problema);
    public void EditProblema(ProblemaSaude.Entity.ProblemaSaude problema);
    public IEnumerable<ProblemaSaude.Entity.ProblemaSaude> GetProblemasDeSaudeByIds(List<int> ids);

    public void DeleteProblema(int id);

}
