using HealthCare_API.Content.Cliente.ValueObject;

namespace HealthCare_API.Content.Cliente.DTO;

public class ClienteDTO
{
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateOnly Nascimento { get; set; }
        public SexoEnum SexoCliente { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public List<global::ProblemaSaude> ProblemasDeSaude { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }

}
