using System;
using System.Collections.Generic;

namespace Meal_Planner_API.Data.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int IngredientId { get; set; }
        public string Name { get; set; }
        public int IngredientCategoryId { get; set; }

        public virtual IngredientCategory IngredientCategory { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
