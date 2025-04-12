﻿using SchoolSystem.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Bll.Dtos
{
   public class GetTeacherDto
    {
        public long TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string SubjectSpecialization { get; set; }
        public ICollection<TeacherClass> TeacherClasses { get; set; }
    }
}
