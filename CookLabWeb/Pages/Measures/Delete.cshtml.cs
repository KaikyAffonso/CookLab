using CookLab.Model;
using CookLab.Service.Ingredients;
using CookLab.Service.Measures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Measures
{
    public class DeleteModel : PageModel
    {
        private readonly IMeasureService _service;

        public DeleteModel(IMeasureService service)
        {
            _service = service;
        }
        public User User { get; set; }
        public IActionResult OnGet(int id)
        {
            GetUser();
            _service.Delete(id);
            return Redirect("/Measures/Measure");
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
