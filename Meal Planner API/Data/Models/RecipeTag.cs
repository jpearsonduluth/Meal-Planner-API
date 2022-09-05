using System;
using System.Collections.Generic;

namespace Meal_Planner_API.Data.Models
{
    public partial class RecipeTag
    {
        public int RecipeTagId { get; set; }
        public int RecipeId { get; set; }
        public int TagId { get; set; }

        public virtual Recipe Recipe { get; set; } = null!;
        public virtual Tag Tag { get; set; } = null!;
    }
}
