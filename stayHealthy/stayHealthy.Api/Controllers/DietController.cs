using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using stayHealthy.Services.Interfaces;
using stayHealthy.Services.Interfaces.Utils;
using stayHealthy.Services.Models.Diet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stayHealthy.Api.Controllers
{
    [Authorize]
    [Route("api/diet")]
    [ApiController]
    public class DietController : ControllerBase
    {
        private readonly IDietService dietService;
        private readonly ILogger<DietController> logger;
        private readonly IAuthProvider authProvider;

        public DietController(IDietService dietService, ILogger<DietController> logger, IAuthProvider authProvider)
        {
            this.dietService = dietService;
            this.logger = logger;
            this.authProvider = authProvider;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DietDetailDto))]
        public async Task<IActionResult> AddDietAsync(DietCreateDto value)
        {
            var userId = authProvider.GetUserId();
            var result = await dietService.CreateDietAsync(value, userId);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DietListItemDto>))]
        public async Task<IActionResult> GetAllDietsAsync()
        {
           var result = await dietService.GetAllDietsAsync();
            return Ok(result);
        }

        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DietListItemDto>))]
        public async Task<IActionResult> GetAllUserDietsAsync()
        {
            var userId = authProvider.GetUserId();
            var result = await dietService.GetAllUserDietsAsync(userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DietDetailDto))]
        public async Task<IActionResult> GetDietByIdAsync(int id)
        {
            var result = await dietService.GetDietByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DietDetailDto))]
        public async Task<IActionResult> UpdateDietAsync(DietUpdateDto value)
        {
            var userId = authProvider.GetUserId();
            var result = await dietService.UpdateDietAsync(value, userId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDietAsync(int id)
        {
            var userId = authProvider.GetUserId();
            logger.LogWarning($"Diet with id: {id} DELETE action invoked");
            await dietService.DeleteDietAsync(id, userId);
            return Ok();
        }

    }
}
