using RecipesShare.Contracts.DTOs.Recipe;
using RecipesShare.DAL.Entities;

namespace RecipesShare.BLL.Abstractions.Mappers
{
    public interface IRecipeMapper
    {
        RecipeDTO MapToDto(Recipe recipe);
        Recipe MapToEntity(CreateRecipeDTO createRecipeDTO);
        void MapToExistEntity(UpdateRecipeDTO updateRecipeDTO, Recipe existingRecipe);
    }
}
