using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IEnrollmentRepository
    {
        Task<bool> IsStudentEnrolledInCourseAsync(Student student, Course course);
        Task EnrollStudentInCourseAsync(Student student, Course course);
    }
}
