using Microsoft.AspNetCore.Mvc;
namespace ContractMonthlyClaim.Controllers
{
    public class ApprovalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
