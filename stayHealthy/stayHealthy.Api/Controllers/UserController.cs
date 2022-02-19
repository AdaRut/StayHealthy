using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stayHealthy.Services.Interfaces;
using stayHealthy.Services.Interfaces.Utils;
using stayHealthy.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stayHealthy.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IAuthProvider authProvider;

        public UserController(IUserService userService, IAuthProvider authProvider)
        {
            this.userService = userService;
            this.authProvider = authProvider;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add([FromBody] UserAdd userAdd)
        {
            var result = await userService.AddUserAsync(userAdd);
            return Ok(result);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update([FromBody] UserModify userModify)
        {
            var userId = authProvider.GetUserId();
            if (authProvider.GetUserRole() == "User" && userModify.Id != userId)
            {
                return BadRequest();
            }
            var result = await userService.UpdateUserAsync(userModify);
            return Ok(result);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var result = await userService.GetUserAsync(userId);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var deletedByUserId = authProvider.GetUserId();
            var result = await userService.DeleteAsync(userId, deletedByUserId);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await userService.GetAllAsync();
            return Ok(result);
        }
    }
}
