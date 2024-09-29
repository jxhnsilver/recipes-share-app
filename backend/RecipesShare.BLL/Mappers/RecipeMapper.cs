using RecipesShare.BLL.Abstractions.Mappers;
using RecipesShare.Contracts.DTOs.Recipe;
using RecipesShare.DAL.Entities;

namespace RecipesShare.BLL.Mappers
{
    public class RecipeMapper : IRecipeMapper
    {
        public RecipeDTO MapToDto(Recipe recipe)
        {
            return new RecipeDTO
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                Ingredients = recipe.Ingredients,
                Instructions = recipe.Instructions,
                CreatedAt = recipe.CreatedAt,
                UpdatedAt = recipe.UpdatedAt
            };
        }

        public Recipe MapToEntity(CreateRecipeDTO createRecipeDTO)
        {
            return new Recipe
            {
                Title = createRecipeDTO.Title,
                Description = createRecipeDTO.Description,
                Ingredients = createRecipeDTO.Ingredients,
                Instructions = createRecipeDTO.Instructions,
            };
        }

        public void MapToExistEntity(UpdateRecipeDTO updateRecipeDTO, Recipe existingRecipe)
        {
            existingRecipe.Title = updateRecipeDTO.Title;
            existingRecipe.Description = updateRecipeDTO.Description;
            existingRecipe.Ingredients = updateRecipeDTO.Ingredients;
            existingRecipe.Instructions = updateRecipeDTO.Instructions;
        }
    }
}
