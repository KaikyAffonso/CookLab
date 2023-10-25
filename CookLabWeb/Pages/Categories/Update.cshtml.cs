using CookLab.Model;
using CookLab.Service.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Categories
{
    public class UpdateModel : PageModel
    {
        private readonly ICategoryService _service;

        public Category Category { get; set; }
        public User User { get; set; }  
        public UpdateModel(ICategoryService service)
        {
            _service = service;
        }
        public void OnGet(int id)
        {
            GetUser();
            Category = _service.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Category category = new Category();
       
            category.Id = Convert.ToInt32(Request.Form["id"]);
            category.Name = Convert.ToString(Request.Form["name"]);
            _service.Update(category);

            return Redirect("/Categories/Category");



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
