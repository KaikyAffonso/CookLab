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


        private readonly IMeasureService _measure;

        public RecipeModel(IRecipeService service, ICategoryService category, IDifficultyService difficulty, IUserService user, IMeasureService measure)
        {

            _service = service;
            _category = category;
            _difficulty = difficulty;
            _user = user;

            _measure = measure;
        }

        public Recipe Recipe { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<Difficulty> Difficulties { get; set; }
        public List<Measure> Measures { get; set; }
        public List<Category> Categories { get; set; }


        public void OnGet()
        {
            Recipes = _service.RetrieveAll();
            Categories = _category.RetrieveAll();
            Difficulties = _difficulty.RetrieveAll();
            Measures = _measure.RetrieveAll();
        }

        public IActionResult OnPost()
        {

            Recipe recipe = new Recipe();
            recipe.Category = new Category();
            recipe.Category.Id = Convert.ToInt32(Request.Form["category"]);

            recipe.Author = new User { Id = 1 };

            recipe.Difficulty = new Difficulty()
            {
                Id = Convert.ToInt32(Request.Form["difficulty"])
            };

            recipe.Title = Convert.ToString(Request.Form["title"]);
            //recipe.Id = Convert.ToInt32(Request.Form["id"]);
            recipe.PrepMethod = Convert.ToString(Request.Form["method"]);
            recipe.PrepTime = Convert.ToInt32(Request.Form["time"]);
            recipe.IsApproved = false;


            recipe =  _service.Create(recipe);
            Recipes = _service.RetrieveAll();

            return RedirectToPage("/Recipes/AddIngredient", new { id = recipe.Id });



        }
    }
}
