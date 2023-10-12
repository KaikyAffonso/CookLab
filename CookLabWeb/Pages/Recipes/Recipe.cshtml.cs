using CookLab.Model;
using CookLab.Service.Categories;
using CookLab.Service.Recipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Recipes
{
    public class RecipeModel : PageModel
    {
        private readonly IRecipeService _service;
        private readonly ICategoryService _category;
        public RecipeModel(IRecipeService service, ICategoryService category)
        {

            _service = service;
            _category = category;
        }
        public List<Recipe> Recipes = new List<Recipe>();
 
        public List<Category> Category { get; set; }

        public void OnGet()
        {
            Recipes = _service.RetrieveAll();
            Category = _category.RetrieveAll();
        }

        public void OnPost()
        {

            Recipe recipe = new Recipe();
            Category category = new Category();
            recipe.Category = category;

            User user = new User();
            recipe.Author = user;

            Difficulty difficulty = new Difficulty();
            recipe.Difficulty = difficulty;

            recipe.Title = Convert.ToString(Request.Form["title"]);
            recipe.Difficulty.Name = Convert.ToString(Request.Form["Difficulty"]);
           // recipe.Ingredient =(Request.Form["ingredients"]);
            recipe.Author.Name = Convert.ToString(Request.Form["user"]);
            recipe.Category.Name = Convert.ToString(Request.Form["category"]);
            recipe.PrepMethod = Convert.ToString(Request.Form["method"]);
            recipe.PrepTime = Convert.ToInt32(Request.Form["time"]);
            recipe.IsApproved = Convert.ToBoolean(Request.Form["name"]);

            recipe.Author = new User();
            recipe.Author.Id = 1; 


            _service.Create(recipe);



            


        }
    }
}
