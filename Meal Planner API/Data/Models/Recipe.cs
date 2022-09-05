using System;
using System.Collections.Generic;

namespace Meal_Planner_API.Data.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
            RecipeTags = new HashSet<RecipeTag>();
        }

        public int RecipeId { get; set; }
        public string? Name { get; set; }
        public int? Rating { get; set; }
        public string? Description { get; set; }
        public string? Directions { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual ICollection<RecipeTag> RecipeTags { get; set; }
    }
}
