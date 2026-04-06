using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    // Constructor
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Tables
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    // Configure relationships
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite key for many-to-many relationship
        modelBuilder.Entity<Enrollment>()
            .HasKey(e => new { e.StudentId, e.CourseId });

        base.OnModelCreating(modelBuilder);
    }
}