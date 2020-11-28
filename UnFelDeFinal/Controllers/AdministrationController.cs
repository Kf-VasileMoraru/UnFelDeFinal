using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnFelDeFinal.Domain;
using UnFelDeFinal.Extern.Roles;

namespace UnFelDeFinal.Controllers
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
            return Ok(roleManager.Roles);
        }


        [HttpGet("ListUsersCount")]
        public IActionResult ListUsersCount()
        {
            return Ok(userManager.Users.Count());
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
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if ( await userManager.IsInRoleAsync(user, role.Name))
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
                var user = await userManager.FindByIdAsync(dto[i].UserId);

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
