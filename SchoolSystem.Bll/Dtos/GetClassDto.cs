using SchoolSystem.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Bll.Dtos
{
   public class GetClassDto
    {
        public long ClassId { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<StudentClass> StudentClasses { get; set; }
        public ICollection<TeacherClass> TeacherClasses { get; set; }
    }
}
