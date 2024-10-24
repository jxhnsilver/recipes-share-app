﻿using RecipesShare.Contracts.DTOs.Category;

namespace RecipesShare.Contracts.DTOs.Recipe
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Ingredients { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
