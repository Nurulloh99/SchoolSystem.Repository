namespace SchoolSystem.Dal.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Dal.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StudentClassConfiguration : IEntityTypeConfiguration<StudentClass>
{
    public void Configure(EntityTypeBuilder<StudentClass> builder)
    {
        builder.ToTable("StudentClasses");

        builder.HasKey(sc => new { sc.StudentId, sc.ClassId });

        builder.HasOne(sc => sc.Student)
               .WithMany(s => s.StudentClasses)
               .HasForeignKey(sc => sc.StudentId);

        builder.HasOne(sc => sc.Class)
               .WithMany(c => c.StudentClasses)
               .HasForeignKey(sc => sc.ClassId);
    }
}

