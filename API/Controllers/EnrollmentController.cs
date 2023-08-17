using Core.Service;
using Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly IEnrollmentRepository _enrollmentRepo;

        public EnrollmentController(ICourseRepository courseRepo, IStudentRepository studentRepo, IEnrollmentRepository enrollmentRepo)
        {
            _courseRepo = courseRepo;
            _studentRepo = studentRepo;
            _enrollmentRepo = enrollmentRepo;
        }

        [HttpPost("enroll-student-into-course")]
        public async Task<IActionResult> EnrollStudentToCourse([FromBody] EnrollStudentToCourseDto enrollDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(ApiResponse.Failed(errors));
            }

            try
            {
                var student = await _studentRepo.GetStudentByIdAsync(enrollDto.StudentId);
                var course = await _courseRepo.GetCourseByIdAsync(enrollDto.CourseId);

                if (student == null)
                {
                    return NotFound(ApiResponse.Success("Student not found."));
                }

                if (course == null)
                {
                    return NotFound(ApiResponse.Success("Course not found."));
                }

                var isStudentEnrolled = await _enrollmentRepo.IsStudentEnrolledInCourseAsync(student, course);
                if (isStudentEnrolled)
                {
                    return Conflict(ApiResponse.Failed("Student is already enrolled in the course."));
                }

                await _enrollmentRepo.EnrollStudentInCourseAsync(student, course);
                return Ok(ApiResponse.Success("Student enrolled successfully."));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed($"{ex}"));
            }
        }


    }
}
