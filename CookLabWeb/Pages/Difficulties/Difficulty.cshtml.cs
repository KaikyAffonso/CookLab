using CookLab.Model;
using CookLab.Service.Difficulties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Difficulties
{
    public class DifficultyModel : PageModel
    {
        private readonly IDifficultyService _service;

        public DifficultyModel(IDifficultyService service)
        {
            _service = service;
        }

        public List<Difficulty> _difficulties = new List<Difficulty>();
        public User User { get; set; }
        public void OnGet()
        {
            GetUser();
            _difficulties = _service.RetrieveAll();

        }
        public void OnPost()
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Name = Convert.ToString(Request.Form["Name"]);
            _service.Create(difficulty);
            _difficulties = _service.RetrieveAll();


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
