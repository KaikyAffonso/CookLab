using CookLab.Model;
using CookLab.Service.Difficulties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Difficulties
{
    public class DeleteModel : PageModel
    {
        private readonly IDifficultyService _service;
        public DeleteModel (IDifficultyService service)
        {
            _service = service; 
        }
        public User User { get; set; }
        public IActionResult OnGet(int id)
        {
            GetUser();
            _service.Delete(id);
            return Redirect("/Difficulties/Difficulty"); 
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
