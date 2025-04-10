namespace SchoolSystem.Dal.Entities;

public class Class
{
    public long ClassId { get; set; }
    public string ClassName { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }

    public ICollection<StudentClass> StudentClasses { get; set; }
    public ICollection<TeacherClass> TeacherClasses { get; set; }
}

