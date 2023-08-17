using Data.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IStudentRepository
    {
        Task<Student> AddStudentAsync (AddStudentDto studentDto); 
        Task<Student> GetStudentByIdAsync(string studentId);
        Task<List<Student>> GetAllStudentsAsync();

        //Task<Student> UpdateStudent (UpdateStudentDto studentDto);
        Task<Student> DeleteStudentAsync (string studentId); 
    }
}
