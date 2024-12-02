using HealthCare_API.Content.Cliente.DTO;
using HealthCare_API.Content.ProblemaSaude.ValueObject;

namespace HealthCare_API.Content.Cliente.Interfaces;

public interface IClienteRepository
{
    public Entity.Cliente GetClienteById(int id);
    public IEnumerable<Entity.Cliente> GetAllClientes();
    public IEnumerable<Entity.Cliente> GetAllClienteByProblema(GrauEnum grauprob);
    public void AddCliente(Entity.Cliente cliente);
    public void UpdateCliente(Entity.Cliente cliente);
    public void DeleteCliente(int id);
    public int CalcularIdade(int id);
}
