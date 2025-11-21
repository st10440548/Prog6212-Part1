using System.Linq;
using CMS.Models;

namespace CMS.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Lecturers.Any())
            {
                context.Lecturers.AddRange(
                    new Lecturer { Name = "Dr. Alice", Email = "alice@example.edu", Department = "Maths" },
                    new Lecturer { Name = "Mr. Bob", Email = "bob@example.edu", Department = "IT" }
                );
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { Username = "lecturer1", Role = "Lecturer", PasswordHash = "pass" },
                    new User { Username = "coord1", Role = "Coordinator", PasswordHash = "pass" },
                    new User { Username = "manager1", Role = "Manager", PasswordHash = "pass" },
                    new User { Username = "hr1", Role = "HR", PasswordHash = "pass" }
                );
                context.SaveChanges();
            }
        }
    }
}
