using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal_Planner_API.APIModels {
	[Serializable]
	public class Ingredient {
		public int IngredientId { get; set; }
		public string Name { get; set; }
		public string IngredientCategory { get; set; }

		public Ingredient() { }
		public Ingredient(Data.Models.Ingredient ingredient) {
			this.IngredientId = ingredient.IngredientId;
			this.Name = ingredient.Name;
			this.IngredientCategory = ingredient.IngredientCategory.Name;
		}

		public Data.Models.Ingredient ToRepo(int categoryId) {
			return new Data.Models.Ingredient {
				IngredientId = this.IngredientId,
				Name = this.Name,
				IngredientCategoryId = categoryId
			};
		}
	}
}
