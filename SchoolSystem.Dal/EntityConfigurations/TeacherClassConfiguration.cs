namespace SchoolSystem.Dal.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Dal.Entities;

public class TeacherClassConfiguration : IEntityTypeConfiguration<TeacherClass>
{
    public void Configure(EntityTypeBuilder<TeacherClass> builder)
    {
        builder.ToTable("TeacherClasses");

        builder.HasKey(tc => new { tc.TeacherId, tc.ClassId });

        builder.HasOne(tc => tc.Teacher)
               .WithMany(t => t.TeacherClasses)
               .HasForeignKey(tc => tc.TeacherId);

        builder.HasOne(tc => tc.Class)
               .WithMany(c => c.TeacherClasses)
               .HasForeignKey(tc => tc.ClassId);   
    }
}

