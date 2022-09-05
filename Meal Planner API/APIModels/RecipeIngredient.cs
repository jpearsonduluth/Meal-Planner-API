using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal_Planner_API.APIModels
{
	[Serializable]
	public class RecipeIngredient {
		public int RecipeIngredientId { get; set; }
		public int RecipeId { get; set; }
		public int IngredientId { get; set; }
		public int MeasureUnitId { get; set; }
		public int Quantity { get; set; }

		public RecipeIngredient() { }
		public RecipeIngredient(Data.Models.RecipeIngredient recipeIngredient) {
			this.RecipeIngredientId = recipeIngredient.RecipeIngredientId;
			this.RecipeId = recipeIngredient.RecipeIngredientId;
			this.IngredientId = recipeIngredient.IngredientId;
			this.MeasureUnitId = recipeIngredient.MeasureUnitId;
			this.Quantity = recipeIngredient.Quantity;
		}
		public Data.Models.RecipeIngredient ToRepo() {
			return new Data.Models.RecipeIngredient {
				RecipeIngredientId = this.RecipeIngredientId,
				RecipeId = this.RecipeId,
				IngredientId = this.IngredientId,
				MeasureUnitId = this.MeasureUnitId,
				Quantity = this.Quantity
			};
		}
	}
}
