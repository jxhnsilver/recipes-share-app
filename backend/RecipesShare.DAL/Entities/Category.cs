﻿namespace RecipesShare.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Recipe> Recipes { get; set; }
    }
}
