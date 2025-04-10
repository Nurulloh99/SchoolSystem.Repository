namespace SchoolSystem.Dal.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Dal.Entities;

public class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.ToTable("Classes");

        builder.HasKey(c => c.ClassId);

        builder.Property(c => c.ClassId)
               .ValueGeneratedOnAdd();

        builder.Property(c => c.ClassName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.Description)
               .HasMaxLength(250);

        builder.Property(c => c.IsActive)
               .IsRequired();

        builder.HasMany(c => c.StudentClasses)
               .WithOne(sc => sc.Class)
               .HasForeignKey(sc => sc.ClassId);

        builder.HasMany(c => c.TeacherClasses)
               .WithOne(tc => tc.Class)
               .HasForeignKey(tc => tc.ClassId);
    }
}

}

