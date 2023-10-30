using CookLab.Model;
using CookLab.Service.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Users
{
    public class ApproveModel : PageModel
    {
        private readonly IUserService _service;
        public ApproveModel(IUserService service)
        {
            _service = service;
        }
        public User User { get; set; }
        public User UserUp { get; set; }
        public IActionResult OnGet(int id)
        {
            GetUser();
            UserUp= _service.Retrieve(id);
            UserUp.IsBlocked = false;
            _service.Update(UserUp);

            return Redirect("/Users/User");

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
