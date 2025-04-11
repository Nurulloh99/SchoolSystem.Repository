using SchoolSystem.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Bll.Services
{
   public interface IStudentService
    {
        Task<long> AddStudentAsync(SetStudentDto studentEntity);
        Task UpdateStudentAsync(SetStudentDto studentEntity);
        Task DeleteStudentAsync(long studentId);
        Task<GetStudentDto> GetStudentByIdAsync(long studentId);
        Task<List<GetStudentDto>> GetAllStudentsAsync(int page, int pageSize, bool includeStudents, bool includeTeachers);
    }
}
