using CookLab.Model;
using CookLab.Service.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Categories
{
    public class RetrieveModel : PageModel
    {
        private readonly ICategoryService _service;

        public Category Category { get; set; }
        public User User { get; set; }

        public RetrieveModel(ICategoryService service)
        {
            _service = service;
        }

        public void OnGet(int id)
        {
            GetUser();
            Category = _service.Retrieve(id);
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
