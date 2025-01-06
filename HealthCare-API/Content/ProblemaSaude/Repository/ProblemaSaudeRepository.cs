using HealthCare_API.Content.ProblemaSaude.Interfaces;
using HealthCare_API.Content.ProblemaSaude.ValueObject;
using HealthCare_API.Context;

namespace HealthCare_API.Content.ProblemaSaude.Repository;

public class ProblemaSaudeRepository : IProblemaSaudeRepository
{
    private readonly AppDbContext _context;

    public ProblemaSaudeRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddProblema(Entity.ProblemaSaude problema)
    {
       _context.Add(problema);
        _context.SaveChanges();
    }

    public void DeleteProblema(int id)
    {
        var problema = GetProblemaByID(id);
        _context.Remove(problema);
        _context.SaveChanges();
    }

    public void EditProblema(Entity.ProblemaSaude problema)
    {
        var problemasaude = _context.ProblemasSaude.Find(problema.Id);
        if (problemasaude != null)
        {
            problemasaude.Nome = problema.Nome;
            problemasaude.Grau = problema.Grau;

            _context.SaveChanges();
        }
        else
        {
            throw new Exception("Problema de saúde não encontrado.");
        }

    }
    public IEnumerable<Entity.ProblemaSaude> GetProblemasDeSaudeByIds(List<int> ids)
    {
        return _context.ProblemasSaude. Where(p => ids.Contains(p.Id)).ToList();
    }


    public IEnumerable<Entity.ProblemaSaude> GetListProblemaSaude()
    {
        var problemassaude = _context.ProblemasSaude.ToList();
        IEnumerable<ProblemaSaude.Entity.ProblemaSaude> listaproblemas = problemassaude;
        return listaproblemas;
    }

    public IEnumerable<Entity.ProblemaSaude> GetListProblemaSaudeByGrauProblema(GrauEnum grau)
    {
        var problemasaude = _context.ProblemasSaude.Where(p => p.Grau == grau).ToList();
        IEnumerable<ProblemaSaude.Entity.ProblemaSaude> problemaSaudes = problemasaude;
        return problemaSaudes;
    }

    public Entity.ProblemaSaude GetProblemaByID(int id)
    {
        ProblemaSaude.Entity.ProblemaSaude problemaSaude = _context.ProblemasSaude.FirstOrDefault(p => p.Id == id);
        return problemaSaude;
    }

}
