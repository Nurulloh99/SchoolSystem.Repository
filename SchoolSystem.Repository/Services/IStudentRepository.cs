using SchoolSystem.Dal.Entities;

namespace SchoolSystem.Repository.Services;

public interface IStudentRepository
{
    Task<long> AddStudentAsync(Student studentEntity);
    Task UpdateStudentAsync(Student studentEntity);
    Task DeleteStudentAsync(long studentId);
    Task<Student> GetStudentByIdAsync(long studentId);
    Task<List<Student>> GetAllStudentsAsync(bool studentClass, bool teacherClass, int skip, int take);

}