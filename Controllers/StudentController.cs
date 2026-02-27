using AutoMapper;
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
        private readonly IMapper mapper;
        public StudentsController(StudentService _studentService,IMapper _mapper)
        {
            studentService = _studentService;
            mapper = _mapper;
        }
        // CREATE
        [HttpPost("create")]
        public async Task<IActionResult> Create(StudentPR.Models.Student student)
        {
            var studentobj = mapper.Map<StudentPR.Models.Student>(student);
            await studentService.CreateAsync(studentobj);
            return Ok(student);
        }
        // READ ALL
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var students = await studentService.GetAllAsync();

            var response = mapper.Map<List<StudentResponseDto>>(students);

            return Ok(response);
        }
        // READ BY ID
        [HttpGet("getById/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await studentService.GetStudentByIdAsync(id);

            if (student == null)
                return NotFound();

            var response = mapper.Map<StudentResponseDto>(student);

            return Ok(response);
        }
        // UPDATE
        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update(int id, StudentRequestDto request)
        {
            var entity = mapper.Map<StudentPR.Models.Student>(request);

            var updated = await studentService.UpdateAsync(entity, id);

            var response = mapper.Map<StudentResponseDto>(updated);

            return Ok(response);
        }
        // DELETE
        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await studentService.DeleteAsync(id);

            return NoContent();
        }
    }
}