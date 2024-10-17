using RecipesShare.Contracts.Common;
using RecipesShare.Contracts.DTOs.Recipe;

namespace RecipesShare.BLL.Abstractions.Services
{
    public interface IRecipeService
    {
        Task<List<RecipeDTO>> GetAllRecipesAsync();
        Task<RecipeDTO> GetRecipeByIdAsync(int id);
        Task<Result> AddRecipeAsync(CreateRecipeDTO createRecipeDTO);
        Task<Result> UpdateRecipeAsync(int id, UpdateRecipeDTO updateRecipeDTO);
        Task<Result> DeleteRecipeAsync(int id);
    }
}
