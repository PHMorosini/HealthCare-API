using System.ComponentModel.DataAnnotations;
using HealthCare_API.Content.Cliente.Entity;
using HealthCare_API.Content.ProblemaSaude.ValueObject;

namespace HealthCare_API.Content.ProblemaSaude.Entity;

public class ProblemaSaude
{
    [Key]
    public int Id { get; set; }
    [StringLength(60, ErrorMessage = "O Nome deve ter no maximo 60 caracteres")]
    [Required(ErrorMessage = "O Nome do problema é obrigatorio!!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O grau do problema é obrigatório")]
    [Range(1, 3, ErrorMessage = "O grau deve ser Baixo (1), Médio (2) ou Alto (3)")]
    public GrauEnum Grau { get; set; }

    public List<Cliente.Entity.Cliente> Clientes { get; set; } = new();
}
