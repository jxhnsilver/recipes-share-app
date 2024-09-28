using RecipesShare.BLL.Abstractions;
using RecipesShare.Contracts.Common;
using RecipesShare.Contracts.DTOs;
using RecipesShare.DAL.Abstractions;
using RecipesShare.DAL.Entities;

namespace RecipesShare.BLL.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<Result> AddRecipeAsync(CreateRecipeDTO createRecipeDTO)
        {
            var recipe = new Recipe
            {
                Title = createRecipeDTO.Title,
                Description = createRecipeDTO.Description,
                Ingredients = createRecipeDTO.Ingredients,
                Instructions = createRecipeDTO.Instructions,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

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
                return new Result { IsSuccess = false, Message = "Recipe can't be deleted." };
            }

            return new Result { IsSuccess = true, Message = "Recipe deleted successfully." };
        }

        public async Task<List<RecipeDTO>> GetAllRecipesAsync()
        {
            var recipeList = await _recipeRepository.GetAllRecipesAsync();

            var recipeDTOList = recipeList.Select(recipe => new RecipeDTO
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                Ingredients = recipe.Ingredients,
                Instructions = recipe.Instructions,
                CreatedAt = recipe.CreatedAt,
                UpdatedAt = recipe.UpdatedAt
            }).ToList();

            return recipeDTOList;
        }

        public async Task<RecipeDTO?> GetRecipeByIdAsync(int id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);

            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }

            var recipeDTO = new RecipeDTO
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                Ingredients = recipe.Ingredients,
                Instructions = recipe.Instructions,
                CreatedAt = recipe.CreatedAt,
                UpdatedAt = recipe.UpdatedAt
            };

            return recipeDTO;
        }

        public async Task<Result> UpdateRecipeAsync(int id, UpdateRecipeDTO updateRecipeDTO)
        {
            var entity = await _recipeRepository.GetRecipeByIdAsync(id);

            if (entity == null)
            {
                return new Result { IsSuccess = false, Message = "Recipe not found." };
            }

            entity.Title = updateRecipeDTO.Title;
            entity.Description = updateRecipeDTO.Description;
            entity.Ingredients = updateRecipeDTO.Ingredients;
            entity.Instructions = updateRecipeDTO.Instructions;
            entity.UpdatedAt = DateTime.UtcNow;

            var affectedRows = await _recipeRepository.UpdateRecipeAsync(entity);
            if (affectedRows == 0)
            {
                return new Result { IsSuccess = false, Message = "Recipe can't be updated." };
            }

            return new Result { IsSuccess = true, Message = "Recipe updated successfully." };
        }
    }
}
