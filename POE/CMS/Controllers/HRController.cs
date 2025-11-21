using Microsoft.AspNetCore.Mvc;
using CMS.Data;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CMS.Controllers
{
    public class HRController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HRController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HR/ApprovedReport -> downloads CSV of approved claims
        public IActionResult ApprovedReport()
        {
            var approved = _context.Claims.Include(c => c.Lecturer).Where(c => c.Status == "Approved").ToList();
            var sb = new StringBuilder();
            sb.AppendLine("ClaimId, Lecturer, HoursWorked, HourlyRate, TotalAmount, SubmissionDate");
            foreach (var c in approved)
            {
                sb.AppendLine($"{c.ClaimId},\"{c.Lecturer?.Name}\",{c.HoursWorked},{c.HourlyRate},{c.TotalAmount},{c.SubmissionDate:O}");
            }
            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            return File(bytes, "text/csv", "ApprovedClaims.csv");
        }
    }
}
