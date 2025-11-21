using Microsoft.EntityFrameworkCore;
using CMS.Models;

namespace CMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<SupportingDocument> SupportingDocuments { get; set; }
        public DbSet<Approval> Approvals { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
