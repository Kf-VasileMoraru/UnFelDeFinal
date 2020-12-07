using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternProj.Domain;
using InternProj.WebApi.Extern.Roles;
using InternProj.WebApi.Extern.Dtos.Roles;

namespace InternProj.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }


        [HttpGet("CreateRole")]
        public async Task CreateRole()
        {
            IdentityRole identityRole1 = new IdentityRole
            {
                Name = "Admin"
            };
            IdentityRole identityRole2 = new IdentityRole
            {
                Name = "CityHallAdmin"
            };

            //await roleManager.CreateAsync(identityRole1);
            //await roleManager.CreateAsync(identityRole2);

        }


        [HttpGet("ListRoles")]
        public IActionResult ListRoles()
        {
            var roleList = roleManager.Roles
                .Select(x => x.Name);


            return Ok(roleList);
        }


        [HttpGet("ListUsersCount")]
        public IActionResult ListUsersCount()
        {
            return Ok(userManager.Users.Count());
        }

        [HttpGet("GetUsersByRole")]
        public async Task<IActionResult> GetUsersByRole(string roleName)
        {

            var role = await roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                return BadRequest("Role id is not valid");
            }

            var dto = new List<UserRoleDto>();

            var userList = await userManager.Users.ToListAsync();


            foreach (var user in userList)
            {
                var userRoleViewModel = new UserRoleDto
                {
                    id = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                dto.Add(userRoleViewModel);
            }

            return Ok(dto);
        }


        [HttpGet("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string userEmail, string roleName)
        {

            var user = await userManager.FindByEmailAsync(userEmail);

            if (user == null)
            {
                return BadRequest("User email is not valid");
            }

            var dto = new UserRoleDto
            {
                id = user.Id,
                UserName = user.UserName
            };
            if (await userManager.IsInRoleAsync(user, roleName))
            {
                dto.IsSelected = true;
            }

            return Ok(dto);
        }

        [HttpPost("ToggleUserCityHallAdminRole")]
        public async Task<IActionResult> ToggleUserCityHallAdminRole([FromBody] ToggleUserCityHallAdminRole dto)
        {
            var user = await userManager.FindByEmailAsync(dto.UserEmail);

            if (user == null)
            {
                return BadRequest("User email is not valid");
            }

            if (dto.Add) { await userManager.RemoveFromRoleAsync(user, "CityHallAdmin"); } else { await userManager.AddToRoleAsync(user, "CityHallAdmin"); }


            return Ok();
        }


        [HttpGet("EditUsersInRole")]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return BadRequest("Role id is not valid");
            }

            var dto = new List<UserRoleDto>();

            var userList = await userManager.Users.ToListAsync();


            foreach (var user in userList)
            {
                var userRoleViewModel = new UserRoleDto
                {
                    id = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                dto.Add(userRoleViewModel);
            }

            return Ok(dto);
        }


        [HttpPost("EditUsersInRole")]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleDto> dto, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return BadRequest("Role din not found");
            }

            for (int i = 0; i < dto.Count; i++)
            {
                var user = await userManager.FindByIdAsync(dto[i].id);

                IdentityResult result = null;

                if (dto[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!dto[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (dto.Count - 1))
                        continue;
                    else
                        return Ok();
                }
            }

            return Ok();
        }
    }
}
