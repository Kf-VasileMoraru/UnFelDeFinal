using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InternProj.WebApi.Extern.Dtos.Auth;
using InternProj.Domain;

namespace InternProj.WebApi.Services
{
    public class UserService : IUserService
    {
        private UserManager<ApplicationUser> userManger;
        private IConfiguration configuration;
        public UserService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManger = userManager;
            this.configuration = configuration;
        }

        public async Task<UserManagerResponseDto> RegisterUserAsync(RegisterDto model)
        {
            if (model == null)
                throw new NullReferenceException("Reigster Model is null");

            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponseDto
                {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false,
                };

            var ApplicationUser = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
            };


            var result = await userManger.CreateAsync(ApplicationUser, model.Password);

            if (result.Succeeded)
            {
                return new UserManagerResponseDto
                {
                    Message = "User created successfully!",
                    IsSuccess = true,
                };
            }

            return new UserManagerResponseDto
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };

        }

        public async Task<UserManagerResponseDto> LoginUserAsync(LoginDto model)
        {
            var user = await userManger.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new UserManagerResponseDto
                {
                    Message = "There is no user with that Email address",
                    IsSuccess = false,
                };
            }

            var result = await userManger.CheckPasswordAsync(user, model.Password);

            if (!result)
                return new UserManagerResponseDto
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                };

            var role = await userManger.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, role.Count == 0 ? "undefined" : role[0] )

            };

            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: configuration["AuthSettings:Issuer"],
                audience: configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponseDto
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo
            };
        }

    }
}
