using CookLab.Model;
using CookLab.Service.Ingredients;
using CookLab.Service.Measures;
using CookLab.Service.Recipes;
using CookLab.Service.RecipesIngredients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Recipes
{
    public class AddIngredientModel : PageModel
    {
        private readonly IRecipeIngredientService _service;
        private readonly IMeasureService _measure;
        private readonly IRecipeService _recipe;
        private readonly IIngredientService _ingredient;

        public AddIngredientModel(IRecipeIngredientService service, IMeasureService measure, IRecipeService recipe, IIngredientService ingredient)
        {
            _service=service;
            _measure=measure;
            _recipe=recipe;
            _ingredient=ingredient;
        }
        public List<RecipeIngredient> RecipeIngredient { get; set; }
        public List<Measure> Measure { get; set; }
        public Recipe RecipeId { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public User User { get; set; }
        public void OnGet(int id)
        {
            GetUser();
            RecipeIngredient = _service.RetrieveAllByRecipeId(id);
            RecipeId = _recipe.Retrieve(id);
            Measure = _measure.RetrieveAll();
            Ingredients = _ingredient.RetrieveAll();
        }

        public void OnPost()
        {

            RecipeIngredient recipeIngredient = new RecipeIngredient();
            recipeIngredient.Recipe = new Recipe();

            recipeIngredient.Recipe.Id = Convert.ToInt32(Request.Form["recipeid"]);
            //int id = recipeIngredient.Recipe.Id;

            recipeIngredient.Measure = new Measure();
            recipeIngredient.Measure.Id = Convert.ToInt32(Request.Form["measure"]);

            recipeIngredient.quantity = Convert.ToInt32(Request.Form["quantity"]);

            recipeIngredient.Ingredient = new Ingredient();
            recipeIngredient.Ingredient.Id = Convert.ToInt32(Request.Form["ingredient"]);

            recipeIngredient = _service.Create(recipeIngredient);
            OnGet(recipeIngredient.Recipe.Id);
           
        }
        private void GetUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                User = JsonSerializer.Deserialize<User>(user);
            }
        }
    }
}
