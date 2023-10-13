using CookLab.Model;
using CookLab.Service.Categories;
using CookLab.Service.Difficulties;
using CookLab.Service.Ingredients;
using CookLab.Service.Measures;
using CookLab.Service.Recipes;
using CookLab.Service.RecipesIngredients;
using CookLab.Service.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace CookLabWeb.Pages.Recipes
{
    public class RecipeModel : PageModel
    {
        private readonly IRecipeService _service;
        private readonly ICategoryService _category;
        private readonly IDifficultyService _difficulty;
        private readonly IUserService _user;
        private readonly IIngredientService _ingredient;
        private readonly IRecipeIngredientService _recipeIngredient;
        private readonly IMeasureService _measure;

        public RecipeModel(IRecipeService service, ICategoryService category, IDifficultyService difficulty, IUserService user, IIngredientService ingredient, IRecipeIngredientService recipeIngredient, IMeasureService measure)
        {

            _service = service;
            _category = category;
            _difficulty = difficulty;
            _user = user;
            _ingredient = ingredient;
            _recipeIngredient = recipeIngredient;
            _measure = measure;
        }

        public Recipe Recipe { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();

        public List<Difficulty> Difficulties { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Measure> Measures { get; set; }
        public List<Category> Categories { get; set; }


        public void OnGet()
        {
        //    Recipes = _service.RetrieveAll();
            Categories = _category.RetrieveAll();
            Difficulties = _difficulty.RetrieveAll();
            Ingredients = _ingredient.RetrieveAll();
            Measures = _measure.RetrieveAll();
        }

        public void OnPost()
        {

            Recipe recipe = new Recipe();

            recipe.Category = new Category()
            {
                Id = Convert.ToInt32(Request.Form["category"])
            };




            recipe.Author = new User { Id = 1 };



            recipe.Difficulty = new Difficulty()
            {
                Id = Convert.ToInt32(Request.Form["difficulty"])
            };

            recipe.Title = Convert.ToString(Request.Form["title"]);
            //recipe.Id = Convert.ToInt32(Request.Form["id"]);
            recipe.PrepMethod = Convert.ToString(Request.Form["method"]);
            recipe.PrepTime = Convert.ToInt32(Request.Form["time"]);
            recipe.IsApproved = Convert.ToBoolean(Request.Form["approved"]);



            Redirect("/Recipes/AddIngredient");
            //Recipes = _service.RetrieveAll();
        }
    }
}
