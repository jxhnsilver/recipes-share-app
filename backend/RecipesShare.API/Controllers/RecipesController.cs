using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesShare.BLL.Abstractions.Services;
using RecipesShare.Contracts.Common;
using RecipesShare.Contracts.DTOs.Recipe;
using System.Security.Claims;

namespace RecipesShare.API.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _recipeService.GetAllRecipesAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _recipeService.GetRecipeByIdAsync(id);
                
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [Authorize(Roles = StaticUserRoles.USER)]
        [HttpPost]
        public async Task<IActionResult> Post(CreateRecipeDTO createRecipeDTO)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _recipeService.AddRecipeAsync(createRecipeDTO, userId);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [Authorize(Roles = StaticUserRoles.USER)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateRecipeDTO updateRecipeDTO)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _recipeService.UpdateRecipeAsync(id, updateRecipeDTO, userId);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [Authorize(Roles = StaticUserRoles.USER)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _recipeService.DeleteRecipeAsync(id, userId);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
