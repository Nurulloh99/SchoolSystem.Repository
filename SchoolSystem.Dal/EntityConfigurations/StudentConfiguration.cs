using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Dal.Entities;

namespace SchoolSystem.Dal.EntityConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(s => s.StudentId);

        builder.Property(s => s.StudentId)
               .ValueGeneratedOnAdd();

        builder.Property(s => s.FirstName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(s => s.LastName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(s => s.DateOfBirth)
               .IsRequired();

        builder.Property(s => s.Gender)
               .HasMaxLength(10);

        builder.Property(s => s.Email)
               .HasMaxLength(100);

        builder.HasMany(s => s.StudentClasses)
               .WithOne(sc => sc.Student)
               .HasForeignKey(sc => sc.StudentId);
    }
}