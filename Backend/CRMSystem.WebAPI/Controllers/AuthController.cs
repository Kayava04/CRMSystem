using CRMSystem.WebAPI.DTOs.Auth;
using CRMSystem.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRMSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(UserService userService)
        : ControllerBase
    {
        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestDto request)
        {
            await userService.SignUp(request.FullName, request.Email, request.Username, request.Password);
            return Ok();
        }
    
        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequestDto request)
        {
            var token = await userService.SignIn(request.Username, request.Password);

            Response.Cookies.Append("jwt", token);
            return Ok();
        }

        [Authorize]
        [HttpPost("signOut")]
        public new IActionResult SignOut()
        {
            Response.Cookies.Delete("jwt");
            return Ok();
        }
    }
}