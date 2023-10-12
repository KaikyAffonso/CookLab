using CookLab.Model;
using CookLab.Service.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Users
{
    public class UserModel : PageModel
    {
        private readonly IUserService _service;
        public UserModel(IUserService service)
        {
            _service=service;
        }

        public List<User> User { get; set; }

        public void OnGet()
        {
            User = _service.RetrieveAll();
        }
        public void OnPost()
        {

            User user = new User();


            user.Name = Convert.ToString(Request.Form["name"]);
            user.Username = Convert.ToString(Request.Form["username"]);
            user.Email = Convert.ToString(Request.Form["email"]);
            user.Password = Convert.ToString(Request.Form["password"]);
            user.IsAdmin = Convert.ToBoolean(Request.Form["admin"]);
            user.IsBlocked = Convert.ToBoolean(Request.Form["blocked"]);



            _service.Create(user);

            User = _service.RetrieveAll();

        }
    }
}
