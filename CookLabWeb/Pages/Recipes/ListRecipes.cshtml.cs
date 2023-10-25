using CookLab.Model;
using CookLab.Service.Categories;
using CookLab.Service.Difficulties;
using CookLab.Service.Recipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Recipes
{
    public class ListRecipesModel : PageModel
    {
        private readonly IRecipeService _service;
      
        
        public ListRecipesModel(IRecipeService service) { 
        
            _service = service;
           
        }

        public List<Recipe> Recipes { get; set; }
        public User User { get; set; }

        public void OnGet()
        {
            GetUser();
            Recipes = _service.RetrieveAll();
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
