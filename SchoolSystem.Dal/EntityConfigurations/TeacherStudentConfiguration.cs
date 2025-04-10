namespace SchoolSystem.Dal.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Dal.Entities;

public class TeacherStudentConfiguration : IEntityTypeConfiguration<TeacherStudent>
{
    public void Configure(EntityTypeBuilder<TeacherStudent> builder)
    {
        builder.ToTable("TeacherStudents");

        builder.HasKey(ts => new { ts.TeacherId, ts.StudentId });

        builder.HasOne(ts => ts.Teacher)
               .WithMany(t => t.TeacherStudents)
               .HasForeignKey(ts => ts.TeacherId);

        builder.HasOne(ts => ts.Student)
               .WithMany(s => s.TeacherStudents)
               .HasForeignKey(ts => ts.StudentId);
    }
}
