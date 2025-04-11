using SchoolSystem.Bll.Dtos;
using SchoolSystem.Dal.Entities;
using SchoolSystem.Repository.Services;

namespace SchoolSystem.Bll.Services;

public class ClassService : IClassService
{
    private readonly IClassRepository _classRepository;

    public ClassService(IClassRepository classRepository)
    {
        _classRepository = classRepository;
    }

    public async Task<long> AddClassAsync(SetClassDto classEntity)
    {
        if (classEntity == null)
        {
            throw new ArgumentNullException(nameof(classEntity));
        }

        var classToAdd = MapToClassEntity(classEntity);
        var addedClass = await _classRepository.AddClassAsync(classToAdd);
        return addedClass;
    }

    public async Task DeleteClassAsync(long classId)
    {
        await _classRepository.DeleteClassAsync(classId);
    }

    public async Task<List<GetClassDto>> GetAllClassesAsync(int page, int pageSize, bool includeStudents, bool includeTeachers)
    {
        // Calculate pagination
        int skip = (page - 1) * pageSize;
        int take = pageSize;

        // Fetch data from repository
        var classes = await _classRepository.GetAllClassesAsync(includeStudents, includeTeachers, skip, take);

        // Map the list of Class entities to a list of GetClassDto
        return classes.Select(classEntity => MapToGetClassDto(classEntity)).ToList();
    }

    public async Task<GetClassDto> GetClassByIdAsync(long classId)
    {
        if (classId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(classId), "Class ID must be greater than zero.");
        }

        var classEntity = await _classRepository.GetClassByIdAsync(classId);

        if (classEntity == null)
        {
            throw new KeyNotFoundException($"Class with ID {classId} not found.");
        }
        return MapToGetClassDto(classEntity);
    }

    public async Task UpdateClassAsync(SetClassDto classEntity)
    {
        if (classEntity == null)
        {
            throw new ArgumentNullException(nameof(classEntity));
        }
        var classToUpdate = MapToClassEntity(classEntity);
        await _classRepository.UpdateClassAsync(classToUpdate);
    }

    private GetClassDto MapToGetClassDto(Class classEntity)
    {
        return new GetClassDto
        {
            ClassId = classEntity.ClassId,
            ClassName = classEntity.ClassName,
            Description = classEntity.Description,
            IsActive = classEntity.IsActive
        };
    }

    private Class MapToClassEntity(SetClassDto classDto)
    {
        return new Class
        {
            ClassName = classDto.ClassName,
            Description = classDto.Description,
            IsActive = classDto.IsActive
        };
    }

   
}
