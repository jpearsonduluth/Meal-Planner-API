using System;
using System.Collections.Generic;

namespace Meal_Planner_API.Data.Models
{
    public partial class RecipeIngredient
    {
        public int RecipeIngredientId { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public int MeasureUnitId { get; set; }
        public int Quantity { get; set; }

        public virtual Ingredient Ingredient { get; set; } = null!;
        public virtual MeasureUnit MeasureUnit { get; set; } = null!;
        public virtual Recipe Recipe { get; set; } = null!;
    }
}
