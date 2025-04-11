using Microsoft.EntityFrameworkCore;
using SchoolSystem.Dal;
using SchoolSystem.Dal.Entities;

namespace SchoolSystem.Repository.Services;

public class TeacherRepository : ITeacherRepository
{
    private readonly MainContext _context;

    public TeacherRepository(MainContext context)
    {
        _context = context;
    }

    public async Task<long> AddTeacherAsync(Teacher teacherEntity)
    {
        await _context.Teachers.AddAsync(teacherEntity);
        await _context.SaveChangesAsync();
        return teacherEntity.TeacherId;
    }

    public async Task DeleteTeacherAsync(long teacherId)
    {
        var deleteTeacher = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == teacherId);
        if (deleteTeacher != null)
        {
            _context.Teachers.Remove(deleteTeacher);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Teacher not found in this method DeleteTeacherAsync");
        }
    }

    public async Task<List<Teacher>> GetAllTeachersAsync(bool includeClasses, bool includeClassStudents, int skip, int take)
    {
        var teachers = await _context.Teachers
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        foreach (var teacher in teachers)
        {
            if (includeClasses)
            {
                
                await _context.Entry(teacher)
                    .Collection(t => t.TeacherClasses)
                    .Query()
                    .Include(tc => tc.Class)
                    .LoadAsync();

                if (includeClassStudents)
                {
                    foreach (var teacherClass in teacher.TeacherClasses)
                    {
                        await _context.Entry(teacherClass.Class)
                            .Collection(c => c.StudentClasses)
                            .LoadAsync();
                    }
                }
            }
        }

        return teachers;
    }

    public async Task<Teacher> GetTeacherByIdAsync(long teacherId)
    {
        var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == teacherId);
        if (teacher != null)
        {
            return teacher;
        }
        else
        {
            throw new Exception("Teacher not found in this method GetTeacherByIdAsync");
        }
    }

    public async Task UpdateTeacherAsync(Teacher teacherEntity)
    {
        var existingTeacher = await GetTeacherByIdAsync(teacherEntity.TeacherId);
        _context.Entry(existingTeacher).CurrentValues.SetValues(teacherEntity);
        await _context.SaveChangesAsync();
    }
}

