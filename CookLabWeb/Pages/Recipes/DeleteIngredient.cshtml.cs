using CookLab.Model;
using CookLab.Service.RecipesIngredients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Recipes
{
    public class DeleteIngredientModel : PageModel
    {
        private readonly IRecipeIngredientService _service;
        public DeleteIngredientModel(IRecipeIngredientService service)
        {
            _service=service;
        }

        public IActionResult OnGet(int id)
        {
            RecipeIngredient recipeIngredient = _service.Retrieve(id);
            Recipe recipe = recipeIngredient.Recipe;
            int recipeId = recipe.Id;

            _service.Delete(id);
            return RedirectToPage("/Recipes/AddIngredient", new { id = recipeId} );
        }
    }
}
