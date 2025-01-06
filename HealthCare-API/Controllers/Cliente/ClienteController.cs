using HealthCare_API.Content.Cliente.Interfaces;
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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
