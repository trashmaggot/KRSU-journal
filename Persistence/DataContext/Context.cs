using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DataContext;

public class Context : DbContext
{
    public DbSet<Order>      Orders      { get; set; }
    public DbSet<Student>    Students    { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Group>      Groups      { get; set; }
    public DbSet<Lesson>     Lessons      { get; set; }
    
    public Context(DbContextOptions<Context> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Attendance
        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Student)
            .WithMany(s => s.Attendances)
            .HasForeignKey(a => a.StudentId);

        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Lesson)
            .WithMany(l => l.Attendances)
            .HasForeignKey(a => a.LessonId);

        // Configure Course
        modelBuilder.Entity<Course>()
            .HasMany(c => c.Groups)
            .WithMany(g => g.Courses)
            .UsingEntity<Dictionary<string, object>>(
                "CourseGroup",
                j => j.HasOne<Group>().WithMany().HasForeignKey("GroupId"),
                j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId"));

        // Configure Group
        modelBuilder.Entity<Group>()
            .HasMany(g => g.Students)
            .WithOne(s => s.Group)
            .HasForeignKey(s => s.GroupId);

        modelBuilder.Entity<Group>()
            .HasMany(g => g.Lessons)
            .WithOne(l => l.Group)
            .HasForeignKey(l => l.GroupId);

        // Configure Lesson
        modelBuilder.Entity<Lesson>()
            .HasOne(l => l.Group)
            .WithMany(g => g.Lessons)
            .HasForeignKey(l => l.GroupId);

        modelBuilder.Entity<Lesson>()
            .HasOne(l => l.Course)
            .WithMany()
            .HasForeignKey(l => l.CourseId);

        // Configure Student
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Group)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.GroupId);

        base.OnModelCreating(modelBuilder);
    }
}