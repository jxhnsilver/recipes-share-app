using RecipesShare.BLL.Abstractions.Mappers;
using RecipesShare.BLL.Abstractions.Services;
using RecipesShare.Contracts.Common;
using RecipesShare.Contracts.DTOs.Recipe;
using RecipesShare.DAL.Abstractions;

namespace RecipesShare.BLL.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeMapper _recipeMapper;
        public RecipeService(IRecipeRepository recipeRepository, IRecipeMapper recipeMapper)
        {
            _recipeRepository = recipeRepository;
            _recipeMapper = recipeMapper;
        }

        public async Task<Result> AddRecipeAsync(CreateRecipeDTO createRecipeDTO)
        {
            var recipe = _recipeMapper.MapToEntity(createRecipeDTO);
            recipe.CreatedAt = DateTime.UtcNow;
            recipe.UpdatedAt = DateTime.UtcNow;

            var affectedRows = await _recipeRepository.AddRecipeAsync(recipe);
            if (affectedRows == 0)
            {
                return new Result { IsSuccess = false, Message = "Failed to add the recipe." };
            }

            return new Result { IsSuccess = true, Message = "Recipe added successfully." };
        }

        public async Task<Result> DeleteRecipeAsync(int id)
        {
            var entity = await _recipeRepository.GetRecipeByIdAsync(id);
            if (entity == null)
            {
                return new Result { IsSuccess = false, Message = "Recipe not found." };
            }

            var affectedRows = await _recipeRepository.DeleteRecipeAsync(entity);
            if (affectedRows == 0)
            {
                return new Result { IsSuccess = false, Message = "Failed to delete the recipe." };
            }

            return new Result { IsSuccess = true, Message = "Recipe deleted successfully." };
        }

        public async Task<List<RecipeDTO>> GetAllRecipesAsync()
        {
            var recipeList = await _recipeRepository.GetAllRecipesAsync();

            return recipeList.Select(recipe => _recipeMapper.MapToDto(recipe)).ToList();
        }

        public async Task<RecipeDTO?> GetRecipeByIdAsync(int id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);

            if (recipe == null)
            {
                throw new ArgumentNullException("Recipe not found.");
            }

            return _recipeMapper.MapToDto(recipe);
        }

        public async Task<Result> UpdateRecipeAsync(int id, UpdateRecipeDTO updateRecipeDTO)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);

            if (recipe == null)
            {
                return new Result { IsSuccess = false, Message = "Failed to update the recipe." };
            }

            _recipeMapper.MapToExistEntity(updateRecipeDTO, recipe);
            recipe.UpdatedAt = DateTime.UtcNow;

            var affectedRows = await _recipeRepository.UpdateRecipeAsync(recipe);
            if (affectedRows == 0)
            {
                return new Result { IsSuccess = false, Message = "Recipe can't be updated." };
            }

            return new Result { IsSuccess = true, Message = "Recipe updated successfully." };
        }
    }
}
