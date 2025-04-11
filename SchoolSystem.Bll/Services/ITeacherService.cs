using SchoolSystem.Bll.Dtos;

namespace SchoolSystem.Bll.Services
{
    public interface ITeacherService
    {
        Task<long> AddTeacherAsync(SetTeacherDto teacherEntity);
        Task UpdateTeacherAsync(SetTeacherDto teacherEntity);
        Task DeleteTeacherAsync(long teacherId);
        Task<GetTeacherDto> GetTeacherByIdAsync(long teacherId);
        Task<List<GetTeacherDto>> GetAllTeachersAsync(int page, int pageSize, bool includeStudents, bool includeClasses);
    }
}