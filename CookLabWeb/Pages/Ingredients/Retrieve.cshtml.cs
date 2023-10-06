using CookLab.Model;
using CookLab.Service.Categories;
using CookLab.Service.Ingredients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Ingredients
{
    public class RetrieveModel : PageModel
    {
        private readonly IIngredientService _service;

        public Ingredient Ingredient { get; set; }

        public RetrieveModel(IIngredientService service)
        {
            _service = service;
        }

        public void OnGet(int id)
        {
            Ingredient = _service.Retrieve(id);
        }
    }
}
