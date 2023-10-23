using CookLab.Repository.RecipesIngredients;
using CookLab.Service.Recipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Recipes
{
    public class DeleteModel : PageModel
    {
        private readonly IRecipeService _service; 
        public DeleteModel(IRecipeService service)
        {
            _service = service;
        }
        public IActionResult OnGet(int id)
        {

            _service.Delete(id);
            return Redirect("/Recipes/ListRecipes");
        }
    }
}
