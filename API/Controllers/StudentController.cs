using Core.Implementation;
using Core.Service;
using Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;
        private readonly ICourseRepository _courseRepo;

        public StudentController(IStudentRepository studentRepo, ICourseRepository courseRepo)
        {
            _studentRepo = studentRepo;
            _courseRepo = courseRepo;
        }

        [HttpPost("add-student")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentDto addStudentDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ApiResponse.Failed(ModelState,"Invalid Input"));
            }
            try
            {
                var addStudent = await _studentRepo.AddStudentAsync(addStudentDto);
                if (addStudent != null)
                {
                    return Ok(ApiResponse.Success("Student was successfully added!"));
                }
                else
                {
                    return BadRequest(ApiResponse.Failed("Oops!, student was not added."));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed($"{ex}" ));
            }
        }



        [HttpGet("course/{courseId}/enrolled-students")]
        public async Task<IActionResult> GetEnrolledStudentsForCourse(string courseId)
        {
            try
            {
                var course = await _courseRepo.GetCourseByIdAsync(courseId);

                if (course == null)
                {
                    return NotFound(ApiResponse.Success("Course not found."));
                }

                var enrolledStudents = await _studentRepo.GetStudentsEnrolledInCourseAsync(courseId);

                var studentsData = enrolledStudents.Select(student =>
                    new
                    {
                        student.Id,
                        student.StudentName
                    }).ToList();

                return Ok(studentsData);
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed($"{ex}"));
            }
        }


    }
}
