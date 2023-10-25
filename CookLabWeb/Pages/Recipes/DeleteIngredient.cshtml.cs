using CookLab.Model;
using CookLab.Service.RecipesIngredients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Recipes
{
    public class DeleteIngredientModel : PageModel
    {
        private readonly IRecipeIngredientService _service;
        public DeleteIngredientModel(IRecipeIngredientService service)
        {
            _service=service;
        }
        public User User { get; set; }
        public IActionResult OnGet(int id)
        {
            GetUser();
            RecipeIngredient recipeIngredient = _service.Retrieve(id);
            Recipe recipe = recipeIngredient.Recipe;
            int recipeId = recipe.Id;

            _service.Delete(id);
            return RedirectToPage("/Recipes/AddIngredient", new { id = recipeId} );
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
