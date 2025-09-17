using Microsoft.AspNetCore.Mvc;
namespace ContractMonthlyClaim.Controllers
{
    public class ClaimsController : Controller
    {
        // Static UI-only prototype actions
        public IActionResult Submit()
        {
            return View();
        }
        public IActionResult MyClaims()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            ViewBag.ClaimId = id;
            return View();
        }
    }
}
