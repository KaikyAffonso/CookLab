using CookLab.Model;
using CookLab.Service.Difficulties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.CookLabObjects
{
    public class DifficultyModel : PageModel
    {
        private readonly IDifficultyService _service;

        public DifficultyModel(IDifficultyService service)
        {
            _service = service;
        }

        public List<Difficulty> _difficulties = new List<Difficulty>();
        public void OnGet()
        {
            _difficulties = _service.RetrieveAll();

        }
        public void OnPost()
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Name= Convert.ToString(Request.Form["Name"]);
            _service.Create(difficulty);
          _difficulties =  _service.RetrieveAll();


        }

    }
}
