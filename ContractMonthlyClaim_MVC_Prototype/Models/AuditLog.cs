using System;
namespace ContractMonthlyClaim.Models
{
    public class AuditLog
    {
        public int LogId { get; set; }
        public int EntityId { get; set; }
        public string EntityType { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
