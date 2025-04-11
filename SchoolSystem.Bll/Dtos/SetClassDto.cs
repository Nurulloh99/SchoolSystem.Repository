using SchoolSystem.Bll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Bll.Dtos
{
   public class SetClassDto
    {
        public string ClassName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
