namespace SchoolSystem.Dal.Entities;

public class StudentClass
{
    public long StudentId { get; set; }
    public Student Student { get; set; }

    public long ClassId { get; set; }
    public Class Class { get; set; } 
}
