using CookLab.Model;
using CookLab.Service.Categories;
using CookLab.Service.Ingredients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Ingredients
{
    public class UpdateModel : PageModel
    {
        private readonly IIngredientService _service;

        public Ingredient Ingredient { get; set; }
        public User User { get; set; }
        public UpdateModel(IIngredientService service)
        {
            _service = service;
        }
        public void OnGet(int id)
        {
            GetUser();
            Ingredient = _service.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Ingredient ingredient = new Ingredient();

            ingredient.Id = Convert.ToInt32(Request.Form["id"]);
            ingredient.Name = Convert.ToString(Request.Form["name"]);
            _service.Update(ingredient);

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
