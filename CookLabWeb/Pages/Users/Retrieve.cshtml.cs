using CookLab.Model;
using CookLab.Service.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Users
{
    public class RetrieveModel : PageModel
    {
        private readonly IUserService _service;
        public User User { get; set; }
        public RetrieveModel(IUserService service)
        {
            _service = service;
        }
        public void OnGet(int id)
        {
            GetUser();
            User =  _service.Retrieve(id);
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
