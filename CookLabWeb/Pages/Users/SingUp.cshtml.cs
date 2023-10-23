using CookLab.Model;
using CookLab.Service.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Users
{
    public class SingUpModel : PageModel
    {
        private readonly IUserService _service;
        public SingUpModel(IUserService service)
        {
            _service=service;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost() {
            User user = new User();


            user.Name = Convert.ToString(Request.Form["name"]);
            user.Username = Convert.ToString(Request.Form["username"]);
            user.Email = Convert.ToString(Request.Form["email"]);
            user.Password = Convert.ToString(Request.Form["password"]);
            user.IsAdmin = false;
            user.IsBlocked = true;



            _service.Create(user);
           return RedirectToPage("/Index");
        }
    }
}
