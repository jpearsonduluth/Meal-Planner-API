using Meal_Planner_API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos {
	/// <summary>
	/// Methods for CRUD operations of Ingredients.
	/// </summary>
	public class IngredientRepo : RepoBase<Ingredient> {
		public IngredientRepo(IConfiguration configuration) : base(configuration)
		{
		}

		/// <summary>
		/// Gets all Ingredients from the DB.
		/// </summary>
		/// <returns>All Ingredients from the DB.</returns>
		public override IEnumerable<Ingredient> Get() {
			return _context.Ingredients;
		}

		/// <summary>
		/// Gets a single Ingredient from the DB by its PK Id.
		/// </summary>
		/// <param name="id">The Id of the Ingredient to be fetched.</param>
		/// <returns>A single Ingredient.</returns>
		public override Ingredient? Get(int id) {
			return _context.Ingredients.SingleOrDefault(r => r.IngredientId == id);
		}

		public IEnumerable<Ingredient> GetByCategory(int categoryId) {
			return _context.Ingredients.Where(i => i.IngredientCategoryId == categoryId);
		}

		/// <summary>
		/// Saves the given Ingredient to the DB.
		/// </summary>
		/// <param name="Ingredient">The Ingredient to saved to the db.</param>
		/// <returns>The Ingredient, with its PK DB Id populated.</returns>
		public override Ingredient Save(Ingredient Ingredient) {
			if (Ingredient.IngredientId > 0) {
				_context.Entry(Ingredient).State = EntityState.Modified;
			}
			else {
				_context.Ingredients.Add(Ingredient);
			}
			_context.SaveChanges();
			return Ingredient;
		}

		/// <summary>
		/// Deletes the given Ingredient from the DB.
		/// </summary>
		/// <param name="id">The PK Id of the Ingredient to be deleted.</param>
		public override void Delete(int id) {
			var toBeDeleted = _context.Ingredients.SingleOrDefault(x => x.IngredientId == id);
			if (toBeDeleted != null) {
				_context.Ingredients.Remove(toBeDeleted);
				_context.SaveChanges();
			}
		}
	}
}