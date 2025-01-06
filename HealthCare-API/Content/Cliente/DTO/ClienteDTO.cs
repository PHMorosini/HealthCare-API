using HealthCare_API.Content.Cliente.ValueObject;
using HealthCare_API.Content.ProblemaSaude.DTO;

namespace HealthCare_API.Content.Cliente.DTO;

public class ClienteDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateOnly Nascimento { get; set; }
    public SexoEnum SexoCliente { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public List<ProblemaSaudeDTO> ProblemasDeSaude { get; set; } = new(); // Lista completa
    public List<int> ProblemasDeSaudeIds => ProblemasDeSaude.Select(p => p.Id).ToList(); // Apenas os IDs
    public decimal Altura { get; set; }
    public decimal Peso { get; set; }
}

