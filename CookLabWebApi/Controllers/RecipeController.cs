using CookLab.Model;
using CookLab.Service.Recipes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CookLabWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _service;

        public RecipeController(IRecipeService service)
        {
            _service=service;
        }


        // GET: api/<RecipeController>
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return _service.RetrieveAll();
        }

        // GET api/<RecipeController>/5
        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            return _service.Retrieve(id);
        }

        // POST api/<RecipeController>
        [HttpPost]
        public Recipe Post([FromBody] Recipe recipe)
        {
            return _service.Create(recipe);
        }

        // PUT api/<RecipeController>/5
        [HttpPut("{id}")]
        public Recipe Put(int id, [FromBody] Recipe recipe)
        {
           return _service.Update(recipe);
        }

        // DELETE api/<RecipeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
