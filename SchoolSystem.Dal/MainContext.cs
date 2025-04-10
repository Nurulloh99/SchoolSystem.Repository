using Microsoft.EntityFrameworkCore;
using SchoolSystem.Dal.Entities;

namespace SchoolSystem.Dal;

public class MainContext : DbContext
{
    public DbSet<Class> Classes { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<StudentClass> StudentClasses { get; set; }
    public DbSet<TeacherClass> TeacherClasses { get; set; }
    public DbSet<TeacherStudent> TeacherStudents { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
