using CookLab.Model;
using CookLab.Service.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryService _service;

        public User User { get; set; }
        public DeleteModel(ICategoryService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            GetUser();
            _service.Delete(id);
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
