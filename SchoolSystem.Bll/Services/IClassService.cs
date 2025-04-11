using SchoolSystem.Bll.Dtos;

namespace SchoolSystem.Bll.Services
{
    public interface IClassService
    {
        Task<long> AddClassAsync(SetClassDto classEntity);
        Task UpdateClassAsync(SetClassDto classEntity);
        Task DeleteClassAsync(long classId);
        Task<GetClassDto> GetClassByIdAsync(long classId);
        Task<List<GetClassDto>> GetAllClassesAsync(int page, int pageSize, bool includeStudents, bool includeTeachers); 
    }
}