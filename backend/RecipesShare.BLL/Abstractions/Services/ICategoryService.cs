using RecipesShare.Contracts.Common;
using RecipesShare.Contracts.DTOs.Category;

namespace RecipesShare.BLL.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task<Result> AddCategoryAsync(CreateCategoryDTO createCategoryDTO);
        Task<Result> UpdateCategoryAsync(int id, UpdateCategoryDTO updateCategoryDTO);
        Task<Result> DeleteCategoryAsync(int id);
    }
}
