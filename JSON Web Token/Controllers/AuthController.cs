using JSON_Web_Token.Models;
using JSON_Web_Token.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSON_Web_Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.Register(model);

            if (!result)
            {
                return BadRequest();
            }

            return Ok($"Successfully registered new user \n\n\twith userName : {model.UserName}");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.Login(model);

            if (!result)
            {
                return BadRequest();
            }

            var tokenString = _authService.GenerateTokenString(model);

            return Ok("Success!\nYour Token : "+tokenString);
        }
    }
}
