using System;
using System.Collections.Generic;
namespace ContractMonthlyClaim.Models
{
    public enum ClaimStatus { Draft, Submitted, Verified, Approved, Settled, Rejected }
    public class Claim
    {
        public int ClaimId { get; set; }
        public int LecturerId { get; set; }
        public int ProgrammeId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public decimal TotalAmount { get; set; }
        public ClaimStatus Status { get; set; }
        public string Notes { get; set; }
        public List<ClaimItem> Items { get; set; } = new();
        public List<Document> Documents { get; set; } = new();
    }
}
