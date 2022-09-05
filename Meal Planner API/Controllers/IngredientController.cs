using Data.Repos;
using Meal_Planner_API.APIModels;
using Meal_Planner_API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Meal_Planner_API.Controllers
{
    [Route("api/Ingredients")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IngredientRepo _repo;

        public IngredientController([FromServices] IngredientRepo repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<APIModels.Ingredient> Get()
        {
            return _repo.Get().Select(x => new APIModels.Ingredient(x));
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIModels.Ingredient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIModels.Ingredient> Get(int id)
        {
            var ingredients = _repo.Get(id);
            if(ingredients != null)
                return new APIModels.Ingredient(ingredients);

            return NotFound("The given ID is not valid.");
        }


        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> Post([FromServices] IngredientCategoriesRepo categoryRepo, [FromBody] APIModels.Ingredient ingredient)
        {
            if (string.IsNullOrWhiteSpace(ingredient.Name))
                return ValidationProblem("Name cannot be null or empty");

            var categoryId = getCategoryId(categoryRepo, ingredient.IngredientCategory);
            
            var saved = _repo.Save(ingredient.ToRepo(categoryId));

            return saved.IngredientId;
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put([FromServices] IngredientCategoriesRepo categoryRepo, int id, APIModels.Ingredient ingredient)
        {
            //a little validation never hurt anyone
            if (id < 1 || id != ingredient.IngredientId)
                return BadRequest("Updating an ingredient requires a valid ID.");
            if (string.IsNullOrWhiteSpace(ingredient.Name))
                return ValidationProblem("Name cannot be null or empty");

            var categoryId = getCategoryId(categoryRepo, ingredient.IngredientCategory);

            _repo.Save(ingredient.ToRepo(categoryId));

            return Ok("Saved!");
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
            }
            catch(Exception ex)
            {
                //might wanna add some logging here, yeah?

                StringBuilder message = new StringBuilder();
                message.AppendLine(ex.Message);

                //probably shouldn't do this if our api is exposed publicly
                while (ex.InnerException != null)
                {
                    message.AppendLine(ex.Message);
                    ex = ex.InnerException;
                }

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

            //we made it this far... all is well
            return Ok("Deleted!");
        }


        /// <summary>
        /// Attempts to pull the cateogry for the given name out of the db.
        /// Will create a new category if not found.
        /// Returns the pk Id of the (existing or newly inserted) cateogry.
        /// </summary>
        private int getCategoryId(IngredientCategoriesRepo categoryRepo, string categoryName)
        {
            int categoryId;

            var category = categoryRepo.Get(categoryName);
            if (category != null)
                categoryId = category.IngredientCategoryId;
            else
                categoryId = categoryRepo.Save(new Data.Models.IngredientCategory { Name = categoryName }).IngredientCategoryId;

            return categoryId;
        }
    }
}
