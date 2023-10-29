using CookLab.Model;
using CookLab.Service.Recipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Recipes
{
    public class ApproveModel : PageModel
    {
        private readonly IRecipeService _service;
        public User User { get; set; }
        public Recipe Recipe { get; set; }
        public ApproveModel(IRecipeService service)
        {
            _service = service;
        }
        public IActionResult OnGet(int id)
        {
            GetUser();
           Recipe = _service.Retrieve(id);
            Recipe.IsApproved = true;
            _service.Update(Recipe);
            return Redirect("/Recipes/ListRecipes");
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
