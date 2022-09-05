using System;
using System.Collections.Generic;

namespace Meal_Planner_API.Data.Models
{
    public partial class Tag
    {
        public Tag()
        {
            RecipeTags = new HashSet<RecipeTag>();
        }

        public int TagId { get; set; }
        public string Value { get; set; } = null!;

        public virtual ICollection<RecipeTag> RecipeTags { get; set; }
    }
}
