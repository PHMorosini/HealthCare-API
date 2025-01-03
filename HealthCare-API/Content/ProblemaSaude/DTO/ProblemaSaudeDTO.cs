using HealthCare_API.Content.ProblemaSaude.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace HealthCare_API.Content.ProblemaSaude.DTO
{
    public class ProblemaSaudeDTO
    {
        public int Id { get; set; }

        [StringLength(60, ErrorMessage = "O Nome deve ter no máximo 60 caracteres.")]
        [Required(ErrorMessage = "O Nome do problema é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O grau do problema é obrigatório.")]
        public GrauEnum Grau { get; set; }
    }
}
