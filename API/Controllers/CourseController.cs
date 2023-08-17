using Core.Service;
using Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;

        public CourseController(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpPost("add-course")]
        public async Task <IActionResult> AddCourse([FromBody]AddCourseDto addCourseDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse.Failed(ModelState, "Invalid input"));
                }
                var courseAdded = await _courseRepo.AddCourseAsync(addCourseDto);
                if (courseAdded != null)
                {
                    return Ok(ApiResponse.Success("Course was added successfully"));
                }
                else
                {
                    return BadRequest(ApiResponse.Failed(ModelState));
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ApiResponse.Failed(ModelState,$"{ex}"));
            }
        }





        //[HttpDelete("delete-course")]
        //public async Task <IActionResult> DeleteCourse(string courseId)
        //{
        //    try
        //    {
        //        var deletedCourse = await _courseRepo.DeleteCourseAsync(courseId);
        //        if (deletedCourse != null)
        //        {
        //            return Ok(ApiResponse.Success("Course was deleted successfully"));
        //        }
        //        else
        //        {
        //            return NotFound(ApiResponse.Success("Course was not found"));
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ApiResponse.Failed($"failed to delete course' {ex}"));
        //    }
        //}

    }
}
