using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InternProj.Extern.Dtos;
using InternProj.WebApi.Extern.Dtos.Auth;
using InternProj.WebApi.Services;

namespace InternProj.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IAuthService userService;
        public AuthController(IAuthService userService)
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
                {
                    return Ok(result);
                }

                return NotFound(result);
            }

            return NotFound("Some properties are not valid");
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

                return NotFound(result);
            }

            return NotFound("Some properties are not valid");
        }



    }
}