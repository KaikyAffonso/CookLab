using CookLab.Model;
using CookLab.Service.Categories;
using CookLab.Service.Recipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Recipes
{
    public class RecipesByCategoryModel : PageModel
    {
        private readonly IRecipeService _service;
        private readonly ICategoryService _category;
        public RecipesByCategoryModel(IRecipeService service, ICategoryService category)
        {
            _service = service;
            _category = category;
        }
        public User User { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<Category> Categories { get; set; }
        public void OnGet()
        {
            GetUser();
            Recipes= _service.RetrieveAll();
            Categories = _category.RetrieveAll();
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
