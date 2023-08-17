using Core.Service;
using Data._DbContext;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Implementation
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        
        private readonly SchoolDbContext _schoolDbContext;

        public EnrollmentRepository(SchoolDbContext schoolDbContext)
        {
            
            _schoolDbContext = schoolDbContext;
        }


        public async Task EnrollStudentInCourseAsync(Student student, Course course)
        {

            // Create a new enrollment
            var enrollment = new Enrollment
            {
                Id = Guid.NewGuid().ToString(),
                StudentId = student.Id,
                CourseId = course.Id,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            _schoolDbContext.Enrollments.Add(enrollment);
            await _schoolDbContext.SaveChangesAsync();
        }



        public async Task<bool> IsStudentEnrolledInCourseAsync(Student student, Course course)
        {
            return await _schoolDbContext.Enrollments
                .AnyAsync(e => e.StudentId == student.Id && e.CourseId == course.Id);
        }


    }
}
