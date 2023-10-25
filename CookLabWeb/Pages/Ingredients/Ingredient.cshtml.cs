using CookLab.Model;
using CookLab.Service.Ingredients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Ingredients
{
    public class IngredientModel : PageModel
    {
        private readonly IIngredientService _service;
        
        public IngredientModel(IIngredientService service)
        {
            _service = service;
        }

        public List<Ingredient> _ingredients = new List<Ingredient>();
        public User User { get; set; }
        public void OnGet()
        {
            GetUser();
            _ingredients = _service.RetrieveAll();
        }

        public void OnPost()
        {
            Ingredient ingridient = new Ingredient();
            ingridient.Name = Convert.ToString(Request.Form["name"]);
            _service.Create(ingridient);
            _ingredients = _service.RetrieveAll();

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
