using System;
using System.Collections.Generic;

namespace Meal_Planner_API.Data.Models
{
    public partial class MeasureUnit
    {
        public MeasureUnit()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int MeasureUnitId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
