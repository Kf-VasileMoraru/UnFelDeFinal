using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternProj.Extern.Dtos.Auth;

namespace InternProj.Services
{
    public interface IUserService
    {
        Task<UserManagerResponseDto> RegisterUserAsync(RegisterDto model);

        Task<UserManagerResponseDto> LoginUserAsync(LoginDto model);
    }
}
