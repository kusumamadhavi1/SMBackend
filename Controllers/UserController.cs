using Microsoft.AspNetCore.Mvc;
using StudentPR.DTOs.Requests;
using StudentPR.DTOs.Responses;
using StudentPR.Services;

namespace StudentPR.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly JwtService _jwtService;

        public UserController(UserService userService, JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userService.ValidateUserAsync(dto);

            if (user == null)
                return Unauthorized("Invalid login");

            var token =_jwtService.GenerateToken(user);

            return Ok(new
            {
                token = token
            });
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user =await _userService.CreateUserAsync(dto);

            // ✅ Return Response DTO (NOT ENTITY)
            var response = new UserResponseDto
            {
                ID = user.ID,
                UserID = user.UserID
            };

            return Ok(response);
        }
    }
}
