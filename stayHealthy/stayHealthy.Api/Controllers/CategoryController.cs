using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stayHealthy.Services.Interfaces;
using stayHealthy.Services.Interfaces.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stayHealthy.Api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IAuthProvider authProvider;
        public CategoryController(
            ICategoryService categoryService,
            IAuthProvider authProvider)
        {
            this.categoryService = categoryService;
            this.authProvider = authProvider;
        }

        [Authorize]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await categoryService.GetAllAsync();
            return Ok(result);
        }
    }
}
