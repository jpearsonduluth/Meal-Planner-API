using Meal_Planner_API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos {
	/// <summary>
	/// Methods for CRUD operations of IngredientCategories.
	/// </summary>
	public class IngredientCategoriesRepo : RepoBase<IngredientCategory> {
		public IngredientCategoriesRepo(IConfiguration configuration) : base(configuration)
		{
		}

		/// <summary>
		/// Gets all IngredientCategories from the DB.
		/// </summary>
		/// <returns>All IngredientCategories from the DB.</returns>
		public override IEnumerable<IngredientCategory> Get() {
			return _context.IngredientCategories;
		}

		/// <summary>
		/// Gets a single IngredientCategory from the DB by its PK Id.
		/// </summary>
		/// <param name="id">The Id of the IngredientCategory to be fetched.</param>
		/// <returns>A single IngredientCategory.</returns>
		public new async Task<IngredientCategory?> Get(int id) {
			return await _context.IngredientCategories.FindAsync(id) ?? null;
		}

        /// <summary>
        /// Gets a single IngredientCategory from the DB by its Name.
        /// </summary>
        /// <param name="id">The Id of the IngredientCategory to be fetched.</param>
        /// <returns>A single IngredientCategory.</returns>
        public IngredientCategory? Get(string name)
        {
            return _context.IngredientCategories?.SingleOrDefault(r => r.Name == name) ?? null;
        }

        /// <summary>
        /// Saves the given IngredientCategory to the DB.
        /// </summary>
        /// <param name="IngredientCategory">The IngredientCategory to saved to the db.</param>
        /// <returns>The IngredientCategory, with its PK DB Id populated.</returns>
        public override IngredientCategory Save(IngredientCategory IngredientCategory) {
			if (IngredientCategory.IngredientCategoryId > 0) {
				_context.Entry(IngredientCategory).State = EntityState.Modified;
			}
			else {
				_context.IngredientCategories.Add(IngredientCategory);
			}
			_context.SaveChanges();
			return IngredientCategory;
		}

		/// <summary>
		/// Deletes the given IngredientCategory from the DB.
		/// </summary>
		/// <param name="id">The PK Id of the IngredientCategory to be deleted.</param>
		public override void Delete(int id) {
			var toBeDeleted = _context.IngredientCategories.SingleOrDefault(x => x.IngredientCategoryId == id);
			if (toBeDeleted != null) {
				_context.IngredientCategories.Remove(toBeDeleted);
				_context.SaveChanges();
			}
		}
	}
}