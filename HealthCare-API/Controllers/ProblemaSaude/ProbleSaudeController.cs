using Microsoft.AspNetCore.Mvc;

namespace HealthCare_API.Controllers.ProblemaSaude
{
    public class ProbleSaudeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
