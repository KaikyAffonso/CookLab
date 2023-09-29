using CookLab.Model;
using CookLab.Service.RecipesIngredients;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CookLabWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {
        private readonly IRecipeIngredientService _recipeIngredientService;
        public RecipeIngredientController(IRecipeIngredientService recipeIngredientService){

            _recipeIngredientService = recipeIngredientService;

}
        // GET: api/<RecipeIngredientController>
        [HttpGet("recipe/{recipeId}")]
        public IEnumerable<RecipeIngredient> GetByRecipeId(int recipeId)
        {
            return _recipeIngredientService.RetrieveAllByRecipeId(recipeId);
        }

        // GET api/<RecipeIngredientController>/5
        [HttpGet("{id}")]
        public RecipeIngredient Get(int id)
        {
            return _recipeIngredientService.Retrieve(id);
        }

        // POST api/<RecipeIngredientController>
        [HttpPost]
        public RecipeIngredient Post([FromBody] RecipeIngredient recipe)
        {
            return _recipeIngredientService.Create(recipe);
        }

        // PUT api/<RecipeIngredientController>/5
        [HttpDelete("recipe/{id}")]
        public void DeleteAllByRecipeId(int id)
        {
            _recipeIngredientService.DeleteAllByRecipeId(id);

        }

        // DELETE api/<RecipeIngredientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _recipeIngredientService.Delete(id);
        }
    }
}
