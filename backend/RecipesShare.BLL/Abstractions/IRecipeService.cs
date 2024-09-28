using RecipesShare.Contracts.Common;
using RecipesShare.Contracts.DTOs;

namespace RecipesShare.BLL.Abstractions
{
    public interface IRecipeService
    {
        Task<List<RecipeDTO>> GetAllRecipesAsync();
        Task<RecipeDTO?> GetRecipeByIdAsync(int id);
        Task<Result> AddRecipeAsync(CreateRecipeDTO createRecipeDTO);
        Task<Result> UpdateRecipeAsync(int id, UpdateRecipeDTO updateRecipeDTO);
        Task<Result> DeleteRecipeAsync(int id);
    }
}
