namespace ContractMonthlyClaim.Models
{
    public class ClaimItem
    {
        public int ItemId { get; set; }
        public int ClaimId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
    }
}
