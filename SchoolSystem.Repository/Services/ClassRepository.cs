using Microsoft.EntityFrameworkCore;
using SchoolSystem.Dal;
using SchoolSystem.Dal.Entities;

namespace SchoolSystem.Repository.Services
{
    public class ClassRepository : IClassRepository
    {
        private readonly MainContext _context;
        public ClassRepository(MainContext context)
        {
            _context = context;
        }
        public async Task<long> AddClassAsync(Class classEntity)
        {
          await _context.Classes.AddAsync(classEntity);
            _context.SaveChanges();
            return classEntity.ClassId;
        }

        public async Task DeleteClassAsync(long classId)
        {
            var deleteClass = await _context.Classes.FirstOrDefaultAsync(x => x.ClassId == classId);
            if (deleteClass != null)
            {
                _context.Classes.Remove(deleteClass);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Class not found in this methot DeleteClassAsync");
            }

        }

        public async Task<List<Class>> GetAllClassesAsync(bool studentClass, bool teacherClass, int skip, int take)
        {
            var classes = await _context.Classes
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            foreach (var cls in classes)
            {
                if (studentClass)
                {
                    await _context.Entry(cls)
                        .Collection(c => c.StudentClasses)
                        .LoadAsync();
                }

                if (teacherClass)
                {
                    await _context.Entry(cls)
                        .Collection(c => c.TeacherClasses)
                        .LoadAsync();
                }
            }

            return classes;
        }



        public async Task<Class> GetClassByIdAsync(long classId)
        {
           var getClassId = await _context.Classes.FirstOrDefaultAsync(x => x.ClassId == classId);
            if (getClassId != null)
            {
                return getClassId;
            }
            else
            {
                throw new Exception("Class not found in this method GetClassByIdAsync");
            }

        }

        public async Task UpdateClassAsync(Class classEntity)
        {
            var updateClass = await GetClassByIdAsync(classEntity.ClassId);
             _context.Classes.Update(updateClass);
            _context.SaveChanges();

        }
    }
}
