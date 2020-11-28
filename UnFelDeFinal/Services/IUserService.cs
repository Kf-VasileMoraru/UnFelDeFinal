using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnFelDeFinal.Extern.Dtos.Auth;

namespace UnFelDeFinal.Services
{
    public interface IUserService
    {
        Task<UserManagerResponseDto> RegisterUserAsync(RegisterDto model);

        Task<UserManagerResponseDto> LoginUserAsync(LoginDto model);
    }
}
