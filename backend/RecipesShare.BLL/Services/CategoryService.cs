using RecipesShare.BLL.Abstractions.Mappers;
using RecipesShare.BLL.Abstractions.Services;
using RecipesShare.Contracts.Common;
using RecipesShare.Contracts.DTOs.Category;
using RecipesShare.DAL.Abstractions;

namespace RecipesShare.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryMapper _categoryMapper;
        public CategoryService(ICategoryRepository categoryRepository, ICategoryMapper categoryMapper)
        {
            _categoryRepository = categoryRepository;
            _categoryMapper = categoryMapper;
        }

        public async Task<Result> AddCategoryAsync(CreateCategoryDTO createCategoryDTO)
        {
            var category = _categoryMapper.MapToEntity(createCategoryDTO);

            var affectedRows = await _categoryRepository.AddCategoryAsync(category);
            if (affectedRows == 0)
            {
                return new Result { IsSuccess = false, Message = "Failed to add the category." };
            }

            return new Result { IsSuccess = true, Message = "Category added successfully." };
        }

        public async Task<Result> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return new Result { IsSuccess = false, Message = "Category not found." };
            }

            var affectedRows = await _categoryRepository.DeleteCategoryAsync(category);
            if (affectedRows == 0)
            {
                return new Result { IsSuccess = false, Message = "Failed to delete the category." };
            }

            return new Result { IsSuccess = true, Message = "Category deleted successfully." };
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categoryList = await _categoryRepository.GetAllCategoriesAsync();

            return categoryList.Select(category => _categoryMapper.MapToDto(category)).ToList();
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            if (category == null)
            {
                throw new ArgumentNullException("Category not found.");
            }

            return _categoryMapper.MapToDto(category);
        }

        public async Task<Result> UpdateCategoryAsync(int id, UpdateCategoryDTO updateCategoryDTO)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return new Result { IsSuccess = false, Message = "Failed to update the category." };
            }

            _categoryMapper.MapToExistEntity(updateCategoryDTO, category);

            var affectedRows = await _categoryRepository.UpdateCategoryAsync(category);
            if (affectedRows == 0)
            {
                return new Result { IsSuccess = false, Message = "Category can't be updated." };
            }

            return new Result { IsSuccess = true, Message = "Category updated successfully." };
        }
    }
}
