using Core.Service;
using Data._DbContext;
using Data.Dtos;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Implementation
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public CourseRepository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }


        public async Task<Course> AddCourseAsync(AddCourseDto addCourseDto)
        {
            var course = new Course()
            {
                Id = Guid.NewGuid().ToString(),
                Name = addCourseDto.Name,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Description = addCourseDto.Description
            };
            _schoolDbContext.Courses.Add(course);
            await _schoolDbContext.SaveChangesAsync();
            return course;
        }

        public async Task<Course> GetCourseByIdAsync(string courseId)
        {
            return await _schoolDbContext.Courses.FindAsync(courseId);
        }
















        //public async Task<Course> DeleteCourseAsync(string courseId)
        //{
        //    var courseToDelete = await _schoolDbContext.Courses.FirstOrDefaultAsync(c => c.Id == courseId);
        //    if (courseToDelete != null)
        //    {
        //        courseToDelete.IsDeleted = true;
        //        courseToDelete.UpdatedAt = DateTime.UtcNow;
        //        await _schoolDbContext.SaveChangesAsync();
        //    }
        //    return courseToDelete;
        //}




    }
}
