using CookLab.Model;
using CookLab.Repository.RecipesIngredients;
using CookLab.Service.Recipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Recipes
{
    public class DeleteModel : PageModel
    {
        private readonly IRecipeService _service; 
        public User User { get; set; }
        public DeleteModel(IRecipeService service)
        {
            _service = service;
        }
        public IActionResult OnGet(int id)
        {
            GetUser();
            _service.Delete(id);
            return Redirect("/Recipes/ListRecipes");
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
