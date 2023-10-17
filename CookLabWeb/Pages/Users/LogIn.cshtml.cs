using CookLab.Model;
using CookLab.Service.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Users
{
    public class LogInModel : PageModel
    {
        private readonly IUserService _service;
        public LogInModel(IUserService service)
        {
            _service=service;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            User user = new User();


            user.Email = Convert.ToString(Request.Form["email"]);
            user.Password = Convert.ToString(Request.Form["password"]);




            //_service.Retrieve(user.Id);
            return RedirectToPage("/Index");

        }
    }
}
