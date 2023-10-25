using CookLab.Model;
using CookLab.Service.Categories;
using CookLab.Service.Recipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Recipes
{
    public class AllRecipeModel : PageModel
    {
        private readonly IRecipeService _service;
        public User User { get; set; }
        public AllRecipeModel(IRecipeService service )
        {
            _service = service;
        
        }

       public Recipe Recipe { get; set; } 
     
        public void OnGet(int id)
        {
            GetUser();
            Recipe = _service.Retrieve(id);
            
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
