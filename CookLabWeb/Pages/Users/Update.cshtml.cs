using CookLab.Model;
using CookLab.Service.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Users
{
    public class UpdateModel : PageModel
    {
        private readonly IUserService _service;

       public User User { get; set; } 
        public UpdateModel(IUserService service)
        {
            _service=service;
        }

        public void OnGet(int id)
        {

            User = _service.Retrieve(id);

        }
        public IActionResult OnPost() {
          
            User user = new User();
            user.Id = Convert.ToInt32(Request.Form["id"]);
            user.Name = Convert.ToString(Request.Form["name"]);
            user.Username = Convert.ToString(Request.Form["username"]);
            user.Email = Convert.ToString(Request.Form["email"]);
            user.Password = Convert.ToString(Request.Form["password"]);
            user.IsAdmin = Convert.ToBoolean(Request.Form["admin"]);
            user.IsBlocked = Convert.ToBoolean(Request.Form["blocked"]);

            _service.Update(user);
            return Redirect("/Users/User"); 


        }
    }
}
