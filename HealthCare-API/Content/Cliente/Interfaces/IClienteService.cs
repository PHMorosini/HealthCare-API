using HealthCare_API.Content.Cliente.DTO;
using HealthCare_API.Content.Cliente.Entity;
using HealthCare_API.Content.ProblemaSaude.ValueObject;

namespace HealthCare_API.Content.Cliente.Interfaces;

public interface IClienteService
{
    ClienteDTO GetClienteById(int id);
    IEnumerable<ClienteDTO> GetAllClientes();
    public void AddCliente(ClienteCreateDTO clientedto);
    public void UpdateCliente(int id, ClienteCreateDTO clienteDto);
    public void DeleteCliente(int id);
    decimal GetClienteProblemaScore(int id);
    IEnumerable<ClienteDTO> GetAllClienteByGrauProblema(GrauEnum grau);

    List<ClienteScore> GetTop10ClientesMaisRisco();
}
