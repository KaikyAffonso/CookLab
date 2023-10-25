using CookLab.Model;
using CookLab.Service.Categories;
using CookLab.Service.Difficulties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Difficulties
{
    public class UpdateModel : PageModel
    {
        private readonly IDifficultyService _service;

        public Difficulty Difficulty { get; set; }
        public User User { get; set; }  
        public UpdateModel(IDifficultyService service)
        {
            _service = service;
        }
        public void OnGet(int id)
        {
            GetUser();
            Difficulty = _service.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Difficulty difficulty = new Difficulty();

            difficulty.Id = Convert.ToInt32(Request.Form["id"]);
            difficulty.Name = Convert.ToString(Request.Form["name"]);
            _service.Update(difficulty);

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
