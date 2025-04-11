using SchoolSystem.Dal.Entities;

namespace SchoolSystem.Repository.Services;

public interface IClassRepository
{
    Task<long> AddClassAsync(Class classEntity);
    Task UpdateClassAsync(Class classEntity);
    Task DeleteClassAsync(long classId);
    Task<Class> GetClassByIdAsync(long classId);
    Task<List<Class>> GetAllClassesAsync(bool studentClass,bool teacherClass,int skip,int take);


}