using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            var authData = await authService.LoginAsync(userLogin);
            if (authData != null)
            {
                return Ok(authData);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        [Route("password/by-user")]
        public async Task<IActionResult> ChangePasswordByUser([FromBody] UserPasswordChange userPasswordChange)
        {
            var result = await authService.ChangePasswordByUserAsync(userPasswordChange);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch]
        [Route("password/by-admin")]
        public async Task<IActionResult> ChangePasswordByAdmin([FromBody] AdminPasswordChange adminPasswordChange)
        {
            var result = await authService.ChangePasswordByAdminAsync(adminPasswordChange);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
