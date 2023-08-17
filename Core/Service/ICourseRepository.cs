using Data.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICourseRepository
    {
        Task<Course> AddCourseAsync(AddCourseDto addCourseDto);
        Task<Course> GetCourseByIdAsync(string courseId);
            
    }
}
