using Microsoft.EntityFrameworkCore;


namespace App.Models
{
    public class StudDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public StudDbContext(DbContextOptions<StudDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
