using CookLab.Model;
using CookLab.Service.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Users
{
    public class LogInModel : PageModel
    {
        private readonly IUserService _service;
        public LogInModel(IUserService service)
        {
            _service=service;
        }
        public User User { get; set; }  
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            SetUser();          
            return RedirectToPage("/Index");

        }
        private void SetUser()
        {
            string username = Convert.ToString(Request.Form["username"]);
            string password = Convert.ToString(Request.Form["password"]);
            User u = _service.Login(username, password);

            string jsonString = JsonSerializer.Serialize(u);

            HttpContext.Session.SetString("user", jsonString);
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
