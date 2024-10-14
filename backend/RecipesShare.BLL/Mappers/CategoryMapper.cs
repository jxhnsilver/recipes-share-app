using RecipesShare.BLL.Abstractions.Mappers;
using RecipesShare.Contracts.DTOs.Category;
using RecipesShare.DAL.Entities;

namespace RecipesShare.BLL.Mappers
{
    public class CategoryMapper : ICategoryMapper
    {
        public CategoryDTO MapToDto(Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
        }

        public Category MapToEntity(CreateCategoryDTO createCategoryDTO)
        {
            return new Category
            {
                Name = createCategoryDTO.Name,
                Description = createCategoryDTO.Description,
            };
        }

        public void MapToExistEntity(UpdateCategoryDTO updateCategoryDTO, Category existingCategory)
        {
            existingCategory.Name = updateCategoryDTO.Name;
            existingCategory.Description = updateCategoryDTO.Description;
        }
    }
}
