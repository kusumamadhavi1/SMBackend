using Microsoft.EntityFrameworkCore;

namespace StudentPR.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)  : base(options) { }

        // Reference the Student type from StudentPR.Models and suppress nullable warnings.
        public DbSet<StudentPR.Models.Student> Students { get; set; } = null!;
        public DbSet<StudentPR.Models.User> Users { get; set; } = null!;
    }
}