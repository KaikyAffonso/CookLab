using CookLab.Model;
using CookLab.Service.Categories;
using CookLab.Service.Ingredients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Ingredients
{
    public class RetrieveModel : PageModel
    {
        private readonly IIngredientService _service;

        public Ingredient Ingredient { get; set; }
        public User User { get; set; }
        public RetrieveModel(IIngredientService service)
        {
            _service = service;
        }

        public void OnGet(int id)
        {
            GetUser();
            Ingredient = _service.Retrieve(id);
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
