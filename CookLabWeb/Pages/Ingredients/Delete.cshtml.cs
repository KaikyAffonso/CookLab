using CookLab.Service.Categories;
using CookLab.Service.Ingredients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Ingredients
{
    public class DeleteModel : PageModel
    {
        private readonly IIngredientService _service;

        public DeleteModel(IIngredientService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            _service.Delete(id);
            return Redirect("/Ingredients/Ingredient");
        }
    }
}
