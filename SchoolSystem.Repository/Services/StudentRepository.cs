using Microsoft.EntityFrameworkCore;
using SchoolSystem.Dal;
using SchoolSystem.Dal.Entities;

namespace SchoolSystem.Repository.Services;

public class StudentRepository : IStudentRepository
{
    private readonly MainContext _context;

    public StudentRepository(MainContext context)
    {
        _context = context;
    }

    public async Task<long> AddStudentAsync(Student studentEntity)
    {
        await _context.Students.AddAsync(studentEntity);
        await _context.SaveChangesAsync();
        return studentEntity.StudentId;
    }

    public async Task DeleteStudentAsync(long studentId)
    {
        var deleteStudent = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == studentId);
        if (deleteStudent != null)
        {
            _context.Students.Remove(deleteStudent);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Student not found in this method DeleteStudentAsync");
        }
    }

    public async Task<List<Student>> GetAllStudentsAsync(bool includeClasses, bool includeClassTeachers, int skip, int take)
    {
        var students = await _context.Students
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        foreach (var student in students)
        {
            if (includeClasses)
            {
                
                await _context.Entry(student)
                    .Collection(s => s.StudentClasses)
                    .Query()
                    .Include(sc => sc.Class) 
                    .LoadAsync();

               
                if (includeClassTeachers)
                {
                    foreach (var studentClass in student.StudentClasses)
                    {
                       
                        await _context.Entry(studentClass.Class)
                            .Collection(c => c.TeacherClasses)
                            .LoadAsync();
                    }
                }
            }
        }

        return students;
    }

    public async Task<Student> GetStudentByIdAsync(long studentId)
    {
        var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == studentId);
        if (student != null)
        {
            return student;
        }
        else
        {
            throw new Exception("Student not found in this method GetStudentByIdAsync");
        }
    }

    public async Task UpdateStudentAsync(Student studentEntity)
    {
        var existingStudent = await GetStudentByIdAsync(studentEntity.StudentId);
        _context.Entry(existingStudent).CurrentValues.SetValues(studentEntity);
        await _context.SaveChangesAsync();
    }
}
