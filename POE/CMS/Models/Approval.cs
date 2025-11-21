using System;
namespace CMS.Models
{
    public class Approval
    {
        public int ApprovalId { get; set; }
        public int ClaimId { get; set; }
        public Claim Claim { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovalDate { get; set; } = DateTime.UtcNow;
        public string Decision { get; set; } // Approved / Rejected
        public string Notes { get; set; }
    }
}
