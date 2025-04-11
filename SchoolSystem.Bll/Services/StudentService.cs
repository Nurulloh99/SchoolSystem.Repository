using SchoolSystem.Bll.Dtos;
using SchoolSystem.Dal.Entities;
using SchoolSystem.Repository.Services;

namespace SchoolSystem.Bll.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<long> AddStudentAsync(SetStudentDto studentDto)
    {
        if (studentDto == null)
        {
            throw new ArgumentNullException(nameof(studentDto));
        }
        var studentToAdd = MapToGetStudentEntity(studentDto);
        var addedStudentId = await _studentRepository.AddStudentAsync(studentToAdd);
        return addedStudentId; 
    }

    public async Task DeleteStudentAsync(long studentId)
    {
        if (studentId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(studentId), "Student ID must be greater than zero.");
        }
        await _studentRepository.DeleteStudentAsync(studentId);
    }

    public async Task<List<GetStudentDto>> GetAllStudentsAsync(int page, int pageSize, bool includeStudents, bool includeTeachers)
    {
        int skip = (page - 1) * pageSize;
        int take = pageSize;

        var students = await _studentRepository.GetAllStudentsAsync(includeStudents, includeTeachers, skip, take);

        return students.Select(classEntity => MapToGetStudentDto(classEntity)).ToList();
    }

    public async Task<GetStudentDto> GetStudentByIdAsync(long studentId)
    {
        if (studentId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(studentId), "Student ID must be greater than zero.");
        }
        var studentEntity = await _studentRepository.GetStudentByIdAsync(studentId);
        if (studentEntity == null)
        {
            throw new KeyNotFoundException($"Student with ID {studentId} not found.");
        }
        return MapToGetStudentDto(studentEntity);
    }

    public async Task UpdateStudentAsync(SetStudentDto studentEntity)
    {
        if (studentEntity == null)
        {
            throw new ArgumentNullException(nameof(studentEntity));
        }
        var studentToUpdate = MapToGetStudentEntity(studentEntity);
        await _studentRepository.UpdateStudentAsync(studentToUpdate);
    }

    private Student MapToGetStudentEntity(SetStudentDto studentDto)
    {
        return new Student
        {
            DateOfBirth = studentDto.DateOfBirth,
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            Gender = studentDto.Gender,
            Email = studentDto.Email,
        };
    }

    private GetStudentDto MapToGetStudentDto(Student student)
    {
        return new GetStudentDto
        {
            DateOfBirth = student.DateOfBirth,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Gender = student.Gender,
            Email = student.Email,
            StudentId = student.StudentId,
        };
    }
}
