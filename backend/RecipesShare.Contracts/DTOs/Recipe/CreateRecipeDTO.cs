﻿namespace RecipesShare.Contracts.DTOs.Recipe
{
    public class CreateRecipeDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Ingredients { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
