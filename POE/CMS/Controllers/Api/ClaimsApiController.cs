using Microsoft.AspNetCore.Mvc;
using CMS.Data;
using System.Linq;

namespace CMS.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ClaimsApiController(ApplicationDbContext context) { _context = context; }

        [HttpGet("status/{id}")]
        public IActionResult Status(int id)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == id);
            if (claim == null) return NotFound();
            return Ok(new { claim.ClaimId, claim.Status, claim.TotalAmount });
        }
    }
}
