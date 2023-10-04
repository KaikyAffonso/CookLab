using CookLab.Model;
using CookLab.Service.Ingredients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.CookLabObjects
{
    public class IngredientsModel : PageModel
    {
        private readonly IIngredientService _service;
        public IngredientsModel(IIngredientService service)
        {
            _service = service;
        }

        public List<Ingredient> _ingredients = new List<Ingredient>();
        public void OnGet()
        {
            _ingredients =  _service.RetrieveAll();
        }

        public void OnPost()
        {
            Ingredient ingridient = new Ingredient();
            ingridient.Name=  Convert.ToString(Request.Form["name"]);
            _service.Create(ingridient);
            _ingredients = _service.RetrieveAll();

        }
    }
}
