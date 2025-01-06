using HealthCare_API.Content.Cliente.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace HealthCare_API.Content.Cliente.DTO;

public class ClienteCreateDTO
{
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(60, ErrorMessage = "O nome deve ter no máximo 60 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateOnly Nascimento { get; set; }

        [Required(ErrorMessage = "O sexo do cliente é obrigatório.")]
        public SexoEnum SexoCliente { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Required]
        public DateTime DataAtualizacao { get; set; }
        public List<int> ProblemasDeSaudeIds { get; set; }

        [Required(ErrorMessage = "A altura é obrigatória.")]
        [Range(0.5, 3.0, ErrorMessage = "A altura deve estar entre 0,5m e 3,0m.")]
        public decimal Altura { get; set; }

        [Required(ErrorMessage = "O peso é obrigatório.")]
        [Range(2, 500, ErrorMessage = "O peso deve estar entre 2kg e 500kg.")]
        public decimal Peso { get; set; }
   
}
