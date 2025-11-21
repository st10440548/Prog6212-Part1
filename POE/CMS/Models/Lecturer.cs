using System.ComponentModel.DataAnnotations;
namespace CMS.Models
{
    public class Lecturer
    {
        public int LecturerId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Email { get; set; }
        public string Department { get; set; }
    }
}
