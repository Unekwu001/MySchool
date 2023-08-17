using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Student : BaseEntity
    {
        public string StudentName { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
