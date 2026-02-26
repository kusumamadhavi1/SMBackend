using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentPR.DTOs.Requests;
using StudentPR.Services;

namespace StudentPR.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService studentService;
        public StudentsController(StudentService _studentService)
        {
            studentService = _studentService;
        }
        // CREATE
        [HttpPost("create")]
        public async Task<IActionResult> Create(StudentPR.Models.Student student)
        {
            await studentService.CreateAsync(student);
            return Ok(student);
        }
        // READ ALL
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()

        {
            var students = await studentService.GetAllAsync();
            return Ok(students);
        }
        // READ BY ID
        [HttpGet("getById/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            var responsedto = new StudentResponseDto
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                PhoneNumber = student.PhoneNumber,
                Address = student.Address,
            };

            return Ok(responsedto);
        }
        // UPDATE
        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update(int id, StudentPR.Models.Student updated)
        {
            var student = await studentService.UpdateAsync(updated, id);
            var responsedto = new StudentResponseDto
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                PhoneNumber = student.PhoneNumber,
                Address = student.Address,
            };

            return Ok(responsedto);
        }
        // DELETE
        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await studentService.DeleteAsync(id);
            return Ok();
        }
    }
}