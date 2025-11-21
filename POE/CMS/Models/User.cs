using System.ComponentModel.DataAnnotations;
namespace CMS.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Role { get; set; } // Lecturer, Coordinator, Manager, HR
        public string PasswordHash { get; set; }
    }
}
