using System.ComponentModel.DataAnnotations;
using HealthCare_API.Content.Cliente.ValueObject;

namespace HealthCare_API.Content.Cliente.Entity;

public class Cliente
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MaxLength(60, ErrorMessage = "O nome deve ter no máximo 60 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
    public DateOnly Nascimento { get; set; }

    [Required(ErrorMessage = "O sexo do cliente é obrigatório.")]
    public SexoEnum SexoCliente { get; set; }

    [Required]
    public DateTime DataCriacao { get; set; }

    [Required]
    public DateTime DataAtualizacao { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "A lista de problemas de saúde é obrigatória.")]
    public List<ProblemaSaude.Entity.ProblemaSaude> ProblemasDeSaude { get; set; } = new();
    [Required(ErrorMessage = "A altura é obrigatória.")]
    [Range(0.5, 3.0, ErrorMessage = "A altura deve estar entre 0,5m e 3,0m.")]
    public decimal Altura { get; set; }

    [Required(ErrorMessage = "O peso é obrigatório.")]
    [Range(2, 500, ErrorMessage = "O peso deve estar entre 2kg e 500kg.")]
    public decimal Peso { get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              


}
