using CookLab.Model;
using CookLab.Service.Difficulties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Difficulties
{
    public class RetrieveModel : PageModel
    {
        private readonly IDifficultyService _service;

       public Difficulty Difficulty { get; set; }
        public User User { get; set; }
        public RetrieveModel (IDifficultyService service)
        {
            _service = service; 
        }
        public void OnGet(int id)
        {
            GetUser();
            _service.Retrieve(id);
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
