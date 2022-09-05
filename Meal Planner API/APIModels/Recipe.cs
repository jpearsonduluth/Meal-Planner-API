using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal_Planner_API.APIModels {
	[Serializable]
	public class Recipe {
		public int RecipeId { get; set; }
		public string Name { get; set; }
		public int Rating { get; set; }
		public string Description { get; set; }
		public string Directions { get; set; }
		public string ImageUrl { get; set; }

		public Recipe() { }
		public Recipe(Data.Models.Recipe recipe) {
			this.RecipeId = recipe.RecipeId;
			this.Name = recipe.Name;
			this.Rating = recipe.Rating.Value;
			this.Description = recipe.Description;
			this.Directions = recipe.Directions;
			this.ImageUrl = recipe.ImageUrl;
		}
		public Data.Models.Recipe ToRepo() {
			return new Data.Models.Recipe {
				RecipeId = this.RecipeId,
				Name = this.Name,
				Rating = this.Rating,
				Description = this.Description,
				Directions = this.Directions,
				ImageUrl = this.ImageUrl
			};
		}
	}
}
