using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternProj.WebApi.Extern.Dtos.Auth;

namespace InternProj.WebApi.Services
{
    public interface IAuthService
    {
        Task<UserManagerResponseDto> RegisterUserAsync(RegisterDto model);

        Task<UserManagerResponseDto> LoginUserAsync(LoginDto model);
    }
}
