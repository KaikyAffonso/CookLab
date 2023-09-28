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
        // GET: api/<RecipeIngredientController>
        [HttpGet]
        public IEnumerable<RecipeIngredient> Get()
        {
            return _recipeIngredientService.RetrieveAll();
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
        [HttpPut("{id}")]
        public RecipeIngredient Put(int id, [FromBody] RecipeIngredient recipe)
        {
          return  _recipeIngredientService.Update(recipe);

        }

        // DELETE api/<RecipeIngredientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _recipeIngredientService.Delete(id);
        }
    }
}
