using System;
using System.Collections.Generic;

namespace Meal_Planner_API.Data.Models
{
    public partial class IngredientCategory
    {
        public IngredientCategory()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        public int IngredientCategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
