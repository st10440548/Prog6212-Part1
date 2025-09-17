using System;
namespace ContractMonthlyClaim.Models
{
    public class Approval
    {
        public int ApprovalId { get; set; }
        public int ClaimId { get; set; }
        public int ApproverId { get; set; }
        public ClaimStatus StatusSet { get; set; }
        public string Comment { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
