using Microsoft.AspNetCore.Mvc;
using CMS.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CMS.Controllers
{
    public class CoordinatorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        public CoordinatorController(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public IActionResult Pending()
        {
            var pending = _context.Claims.Where(c => c.Status == "Pending").ToList();
            // attach a flag if it violates policy
            var maxHours = _config.GetValue<decimal>("ClaimPolicy:MaxHoursPerClaim");
            var maxRate = _config.GetValue<decimal>("ClaimPolicy:MaxHourlyRate");
            ViewBag.MaxHours = maxHours;
            ViewBag.MaxRate = maxRate;
            return View(pending);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == id);
            if (claim != null)
            {
                claim.Status = "Approved";
                _context.Approvals.Add(new Models.Approval { ClaimId = claim.ClaimId, ApprovedBy = "Coordinator", Decision = "Approved" });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Pending));
        }

        [HttpPost]
        public async Task<IActionResult> Reject(int id, string notes)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == id);
            if (claim != null)
            {
                claim.Status = "Rejected";
                _context.Approvals.Add(new Models.Approval { ClaimId = claim.ClaimId, ApprovedBy = "Coordinator", Decision = "Rejected", Notes = notes });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Pending));
        }
    }
}
