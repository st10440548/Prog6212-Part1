using System;
namespace ContractMonthlyClaim.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public int ClaimId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string StoragePath { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
