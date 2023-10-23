using CookLab.Model;
using CookLab.Service.Recipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRecipeService _recipe;


        public IndexModel(ILogger<IndexModel> logger, IRecipeService recipe)
        {
            _logger = logger;
            _recipe = recipe;
        }

        public List<Recipe> Recipes { get; set; }
        public User User { get; set; }  
        public void OnGet()
        {
            GetUser();
            Recipes = _recipe.RetrieveAll();
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