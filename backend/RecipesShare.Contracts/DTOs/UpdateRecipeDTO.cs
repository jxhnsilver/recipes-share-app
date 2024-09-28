﻿namespace RecipesShare.Contracts.DTOs
{
    public class UpdateRecipeDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Ingredients { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
    }
}
