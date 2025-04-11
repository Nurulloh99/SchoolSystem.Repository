namespace SchoolSystem.Dal.Entities;

public class Student
{
    public long StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public ICollection<StudentClass> StudentClasses { get; set; }
}

