using RecipesShare.Contracts.Common;
using RecipesShare.Contracts.DTOs.Recipe;

namespace RecipesShare.BLL.Abstractions.Services
{
    public interface IRecipeService
    {
        Task<List<RecipeDTO>> GetAllRecipesAsync();
        Task<Result<RecipeDTO>> GetRecipeByIdAsync(int id);
        Task<Result> AddRecipeAsync(CreateRecipeDTO createRecipeDTO, int userId);
        Task<Result> UpdateRecipeAsync(int id, UpdateRecipeDTO updateRecipeDTO, int userId);
        Task<Result> DeleteRecipeAsync(int id, int userId);
    }
}
