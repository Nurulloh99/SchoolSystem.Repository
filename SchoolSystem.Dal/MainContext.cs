using Microsoft.EntityFrameworkCore;
using SchoolSystem.Dal.Entities;
using SchoolSystem.Dal.EntityConfigurations;

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
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        modelBuilder.ApplyConfiguration(new ClassConfiguration());
        modelBuilder.ApplyConfiguration(new StudentClassConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherClassConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherStudentConfiguration());
    }

}
