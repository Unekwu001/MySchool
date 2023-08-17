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

        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
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


    }
}
