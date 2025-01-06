using HealthCare_API.Content.Cliente.DTO;
using HealthCare_API.Content.Cliente.Interfaces;
using HealthCare_API.Content.ProblemaSaude.DTO;
using HealthCare_API.Content.ProblemaSaude.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare_API.Controllers.Cliente
{
    /// <summary>
    /// Controlador responsável pelas operações de gerenciamento de clientes.
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteservice) 
        { 
            _clienteService = clienteservice;
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteById(int id)
        {
           var cliente =  _clienteService.GetClienteById(id);
            try{
                if(cliente != null)
                {
                    return Ok(cliente);
                }
                else{ return BadRequest("O Cliente não foi encontrado");}
            }
            catch(Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetListaCliente()
        {
            var listaclientes = _clienteService.GetAllClientes();
            try
            {
                if (listaclientes != null && listaclientes.Any())
                {
                    return Ok(listaclientes);
                }
                else { return BadRequest("Não foi possivel retornar a lista de clientes"); }
            } 
            catch (Exception ex){ return BadRequest(ex.Message);}
        }

        [HttpGet("{grau}")]
        public IActionResult GetListaClienteByGrauProblema(GrauEnum grau) 
        {
            var listaclientes  = _clienteService.GetAllClienteByGrauProblema(grau);
            try
            {
                if (listaclientes != null && listaclientes.Any())
                {
                    return Ok(listaclientes);
                }
                else { return BadRequest("Não foi possivel retornar a lista de clientes"); }
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public IActionResult AddCliente([FromBody] ClienteCreateDTO clienteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _clienteService.AddCliente(clienteDto);
            return CreatedAtAction(nameof(GetClienteById), new { id = clienteDto.Id }, clienteDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            _clienteService.DeleteCliente(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, [FromBody] ClienteCreateDTO clienteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clienteExistente = _clienteService.GetClienteById(id);
            if (clienteExistente == null)
                return NotFound(new { Message = "Cliente não encontrado." });

            _clienteService.UpdateCliente(id, clienteDto);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetTop10ClientesMaisRisco()
        {
            var clientes = _clienteService.GetTop10ClientesMaisRisco();
            try
            {
                if (clientes != null && clientes.Any())
                {
                    return Ok(clientes);
                }
                else{
                    return BadRequest("Não foi possivel retornar a lista de clientes");
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
