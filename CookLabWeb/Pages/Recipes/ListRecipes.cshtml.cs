using CookLab.Model;
using CookLab.Service.Categories;
using CookLab.Service.Difficulties;
using CookLab.Service.Recipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Recipes
{
    public class ListRecipesModel : PageModel
    {
        private readonly IRecipeService _service;
      

        public ListRecipesModel(IRecipeService service) { 
        
            _service = service;
           
        }

        public List<Recipe> Recipes { get; set; }


        public void OnGet()
        {
            Recipes = _service.RetrieveAll();
        }
    }
}
