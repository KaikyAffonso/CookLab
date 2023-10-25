using CookLab.Model;
using CookLab.Service.Categories;
using CookLab.Service.Ingredients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Ingredients
{
    public class DeleteModel : PageModel
    {
        private readonly IIngredientService _service;
        public User User { get; set; }
        public DeleteModel(IIngredientService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            GetUser();
            _service.Delete(id);
            return Redirect("/Ingredients/Ingredient");
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
