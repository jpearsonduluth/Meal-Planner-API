using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal_Planner_API.APIModels {
	[Serializable]
	public class IngredientCategory {
		public int IngredientCategoryId { get; set; }
		public string Name { get; set; }

		public IngredientCategory() { }
		public IngredientCategory(Data.Models.IngredientCategory IngredientCategory) {
			this.IngredientCategoryId = IngredientCategory.IngredientCategoryId;
			this.Name = IngredientCategory.Name;
		}
		public Data.Models.IngredientCategory ToRepo() {
			return new Data.Models.IngredientCategory {
				IngredientCategoryId = this.IngredientCategoryId,
				Name = this.Name
			};
		}
	}
}
