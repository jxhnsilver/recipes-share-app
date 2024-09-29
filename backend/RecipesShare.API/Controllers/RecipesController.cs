using Microsoft.AspNetCore.Mvc;
using RecipesShare.BLL.Abstractions.Services;
using RecipesShare.Contracts.DTOs.Recipe;

namespace RecipesShare.API.Controllers
{
    [Route("api/[controller]")]
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
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateRecipeDTO createRecipeDTO)
        {
            var result = await _recipeService.AddRecipeAsync(createRecipeDTO);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateRecipeDTO updateRecipeDTO)
        {            
            var result = await _recipeService.UpdateRecipeAsync(id, updateRecipeDTO);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _recipeService.DeleteRecipeAsync(id);
            return Ok(result);
        }
    }
}
