using CookLab.Model;
using CookLab.Service.Categories;
using CookLab.Service.Difficulties;
using CookLab.Service.Recipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Recipes
{
    public class UpdateRecipeModel : PageModel
    {
        private readonly IRecipeService _service;
        private readonly ICategoryService _category;
        private readonly IDifficultyService _difficulty;
        public UpdateRecipeModel(IRecipeService service, ICategoryService category, IDifficultyService difficulty)
        {
            _service = service;
            _category = category;
            _difficulty = difficulty;
        }

        public Recipe Recipe { get; set; } 
        public List<Difficulty> Difficulties { get; set; }
        public List<Category> Categories { get; set; }
        public User User { get; set; }
        public void OnGet(int id)
        {
            GetUser();
            Recipe = _service.Retrieve(id);
            Categories = _category.RetrieveAll();
            Difficulties = _difficulty.RetrieveAll();
        }

        public IActionResult OnPost() {
            Recipe recipe = new Recipe();
            recipe.Category = new Category();
            recipe.Category.Id = Convert.ToInt32(Request.Form["category"]);

            recipe.Author = new User();
            recipe.Author.Id = Convert.ToInt32(Request.Form["userid"]); ;

            recipe.Difficulty = new Difficulty()
            {
                Id = Convert.ToInt32(Request.Form["difficulty"])
            };

            recipe.Title = Convert.ToString(Request.Form["title"]);
            recipe.Id = Convert.ToInt32(Request.Form["id"]);
            recipe.PrepMethod = Convert.ToString(Request.Form["method"]);
            recipe.PrepTime = Convert.ToInt32(Request.Form["time"]);
            recipe.IsApproved = Convert.ToBoolean(Request.Form["approved"]);


            recipe =  _service.Update(recipe);
            

            return RedirectToPage("/Recipes/AddIngredient", new { id = recipe.Id });

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
