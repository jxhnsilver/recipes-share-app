using RecipesShare.Contracts.DTOs.Category;
using RecipesShare.DAL.Entities;

namespace RecipesShare.BLL.Abstractions.Mappers
{
    public interface ICategoryMapper
    {
        CategoryDTO MapToDto(Category category);
        Category MapToEntity(CreateCategoryDTO createCategoryDTO);
        void MapToExistEntity(UpdateCategoryDTO updateCategoryDTO, Category existingCategory);
    }
}
