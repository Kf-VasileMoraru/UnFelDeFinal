using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InternProj.Extern.Dtos;
using InternProj.Extern.Dtos.Auth;
using InternProj.Services;

namespace InternProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IUserService userService;
        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        // /api/auth/register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterDto dto)
        {
            if(ModelState.IsValid)
            {
                var result = await userService.RegisterUserAsync(dto);

                if (result.IsSuccess)
                    return Ok(result); // Status Code: 200 

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid"); // Status code: 400
        }

        // /api/auth/login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginDto dto)
        {
            if(ModelState.IsValid)
            {
                var result = await userService.LoginUserAsync(dto);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }



    }
}