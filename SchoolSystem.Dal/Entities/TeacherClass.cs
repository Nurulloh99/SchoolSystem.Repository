﻿namespace SchoolSystem.Dal.Entities;

public class TeacherClass
{
    public long TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public long ClassId { get; set; }
    public Class Class { get; set; }
}
     
