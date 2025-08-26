using E_Comm.Server.Entities;
using E_Comm.Server.ModelDto;
using E_Comm.Server.Services.AuthService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace E_Comm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
           private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Login request cannot be null");
            }
            try
            {
                var response = await _authService.Login(loginRequest);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            
        }
        [HttpGet("CheckEmailExist")]
        public async Task<IActionResult> EmailExist(string email)
        {
            var result = await _authService.CheckEmailExist(email);
            return Ok(result);
        }




        //[HttpPost("Registration")]
        //public async Task<IActionResult> Register(User user)
        //{
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }
        //    var result = await _authService.Register(user);

        //    return Ok(result);
        //}
    }
}
