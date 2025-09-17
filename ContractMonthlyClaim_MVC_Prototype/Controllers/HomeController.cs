using Microsoft.AspNetCore.Mvc;
namespace ContractMonthlyClaim.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
