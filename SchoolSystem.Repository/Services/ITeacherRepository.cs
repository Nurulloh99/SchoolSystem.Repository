using SchoolSystem.Dal.Entities;

namespace SchoolSystem.Repository.Services;

public interface ITeacherRepository
{
    Task<long> AddTeacherAsync(Teacher studentEntity);
    Task UpdateTeacherAsync(Teacher studentEntity);
    Task DeleteTeacherAsync(long studentId);
    Task<Teacher> GetTeacherByIdAsync(long studentId);
    Task<List<Teacher>> GetAllTeachersAsync(bool studentClass, bool teacherClass, int skip, int take);
}