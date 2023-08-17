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
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public StudentRepository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public async Task<Student> AddStudentAsync(AddStudentDto studentDto)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid().ToString(),
                StudentName = studentDto.StudentName,
                DateOfBirth = studentDto.DateOfBirth.Date,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,      
            };
             _schoolDbContext.Students.Add(student);
            await _schoolDbContext.SaveChangesAsync();
            return student;
        }


        public async Task<Student> GetStudentByIdAsync(string studentId)
        {
            return await _schoolDbContext.Students.FindAsync(studentId); 
        }


        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _schoolDbContext.Students.ToListAsync();
        }




        public async Task<Student> DeleteStudentAsync(string studentId)
        {
            var student = await _schoolDbContext.Students.FirstOrDefaultAsync(student => student.Id == studentId);
            if (student != null)
            {
                student.IsDeleted = true;
                student.UpdatedAt = DateTime.UtcNow;

                //_schoolDbContext.Students.Remove(student);
                await _schoolDbContext.SaveChangesAsync();
            }
            return student;
        }





    }
}
