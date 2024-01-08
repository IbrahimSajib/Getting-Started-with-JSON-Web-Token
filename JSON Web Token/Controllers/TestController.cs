using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSON_Web_Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("This is Public");
        }

        [Authorize]
        [HttpGet("Private")]
        public IActionResult Private()
        {
            return Ok("This is Private");
        }     
        
    }
}
