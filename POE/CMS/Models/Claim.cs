using System;
using System.ComponentModel.DataAnnotations;
namespace CMS.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        [Required] public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        [Required]
        [Range(0.1, 10000, ErrorMessage = "Hours must be positive")]
        public decimal HoursWorked { get; set; }

        [Required]
        [Range(0.01, 100000, ErrorMessage = "Rate must be positive")]
        public decimal HourlyRate { get; set; }

        public decimal TotalAmount => HoursWorked * HourlyRate;

        public string Notes { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
    }
}
