using Application.UserCases;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto.Request;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRegistrationUseCase _userRegistrationUseCase;

        public UserController(UserRegistrationUseCase userRegistrationUseCase)
        {
            _userRegistrationUseCase = userRegistrationUseCase;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationRequest request)
        {
            try
            {
                await _userRegistrationUseCase.RegisterUserAsync(request.Username, request.Password, request.Email);
                return Ok(new { Message = "User registered successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
