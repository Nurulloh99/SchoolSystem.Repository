namespace SchoolSystem.Dal.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Dal.Entities;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers");

        builder.HasKey(t => t.TeacherId);

        builder.Property(t => t.TeacherId)
               .ValueGeneratedOnAdd();

        builder.Property(t => t.FirstName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(t => t.LastName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(t => t.DateOfBirth)
               .IsRequired();

        builder.Property(t => t.Gender)
               .HasMaxLength(10);

        builder.Property(t => t.PhoneNumber)
               .HasMaxLength(20);

        builder.Property(t => t.Email)
               .HasMaxLength(100);

        builder.Property(t => t.SubjectSpecialization)
               .HasMaxLength(100);

        builder.HasMany(t => t.TeacherClasses)
               .WithOne(tc => tc.Teacher)
               .HasForeignKey(tc => tc.TeacherId);
    }
}

