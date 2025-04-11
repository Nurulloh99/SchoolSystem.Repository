using SchoolSystem.Bll.Dtos;
using SchoolSystem.Dal.Entities;
using SchoolSystem.Repository.Services;

namespace SchoolSystem.Bll.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;

    public TeacherService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<long> AddTeacherAsync(SetTeacherDto teacherEntity)
    {
        if (teacherEntity == null)
        {
            throw new ArgumentNullException(nameof(teacherEntity));
        }
        var teacherToAdd = MapToGetTeacherEntity(teacherEntity);
        var addedTeacherId = await _teacherRepository.AddTeacherAsync(teacherToAdd);
        return addedTeacherId;
    }

    public async Task DeleteTeacherAsync(long teacherId)
    {
        if (teacherId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(teacherId), "Teacher ID must be greater than zero.");
        }
        await _teacherRepository.DeleteTeacherAsync(teacherId);
    }

    public async Task<List<GetTeacherDto>> GetAllTeachersAsync(int page, int pageSize, bool includeStudents, bool includeClasses)
    {
        int skip = (page - 1) * pageSize;
        int take = pageSize;
        var teachers = await _teacherRepository.GetAllTeachersAsync(includeStudents, includeClasses, skip, take);
        return teachers.Select(teacherEntity => MapToGetTeacherDto(teacherEntity)).ToList();
    }

    public async Task<GetTeacherDto> GetTeacherByIdAsync(long teacherId)
    {
        if (teacherId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(teacherId), "Teacher ID must be greater than zero.");
        }
        var teacherEntity = await _teacherRepository.GetTeacherByIdAsync(teacherId);
        if (teacherEntity == null)
        {
            throw new KeyNotFoundException($"Teacher with ID {teacherId} not found.");
        }
        return MapToGetTeacherDto(teacherEntity);
    }

    public async Task UpdateTeacherAsync(SetTeacherDto teacherEntity)
    {
        if (teacherEntity == null)
        {
            throw new ArgumentNullException(nameof(teacherEntity));
        }
        var teacherToUpdate = MapToGetTeacherEntity(teacherEntity);
        await _teacherRepository.UpdateTeacherAsync(teacherToUpdate);
    }

    private Teacher MapToGetTeacherEntity(SetTeacherDto teacherEntity)
    {
        return new Teacher
        {
            FirstName = teacherEntity.FirstName,
            LastName = teacherEntity.LastName,
            DateOfBirth = teacherEntity.DateOfBirth,
            Gender = teacherEntity.Gender,
            PhoneNumber = teacherEntity.PhoneNumber,
            Email = teacherEntity.Email,
            SubjectSpecialization = teacherEntity.SubjectSpecialization
        };
    }

    private GetTeacherDto MapToGetTeacherDto(Teacher teacherDto)
    {
        return new GetTeacherDto
        {
            FirstName = teacherDto.FirstName,
            LastName = teacherDto.LastName,
            DateOfBirth = teacherDto.DateOfBirth,   
            Gender = teacherDto.Gender,
            PhoneNumber = teacherDto.PhoneNumber,
            Email = teacherDto.Email,
            SubjectSpecialization = teacherDto.SubjectSpecialization
        };
    }
}
