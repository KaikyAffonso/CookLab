using CookLab.Model;
using CookLab.Service.Categories;
using CookLab.Service.Difficulties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Difficulties
{
    public class UpdateModel : PageModel
    {
        private readonly IDifficultyService _service;

        public Difficulty Difficulty { get; set; }
        public UpdateModel(IDifficultyService service)
        {
            _service = service;
        }
        public void OnGet(int id)
        {
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
    }
}
