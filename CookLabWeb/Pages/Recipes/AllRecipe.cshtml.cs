using CookLab.Model;
using CookLab.Service.Categories;
using CookLab.Service.Recipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Recipes
{
    public class AllRecipeModel : PageModel
    {
        private readonly IRecipeService _service;
        
        public AllRecipeModel(IRecipeService service )
        {
            _service = service;
        
        }

       public Recipe Recipe { get; set; } 
     
        public void OnGet(int id)
        {
            Recipe = _service.Retrieve(id);
            
        }
    }
}
