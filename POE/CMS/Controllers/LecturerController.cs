using Microsoft.AspNetCore.Mvc;
using CMS.Data;
using CMS.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CMS.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LecturerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lecturer/Submit
        public IActionResult Submit()
        {
            return View();
        }

        // POST: Lecturer/Submit
        [HttpPost]
        public async Task<IActionResult> Submit(Claim claim, IFormFile file)
        {
            if (!ModelState.IsValid)
                return View(claim);

            // save claim
            _context.Claims.Add(claim);
            await _context.SaveChangesAsync();

            // handle file if exists
            if (file != null && file.Length > 0)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                var filePath = Path.Combine(uploads, Path.GetFileName(file.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                _context.SupportingDocuments.Add(new SupportingDocument {
                    ClaimId = claim.ClaimId,
                    FileName = file.FileName,
                    FilePath = filePath
                });
                await _context.SaveChangesAsync();
            }

            // simple auto-validation: if claim under policy, mark for quick-approve flag (no action here)
            return RedirectToAction(nameof(Submitted));
        }

        public IActionResult Submitted() => View();
    }
}
