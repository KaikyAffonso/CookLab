using CookLab.Model;
using CookLab.Service.Difficulties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Difficulties
{
    public class RetrieveModel : PageModel
    {
        private readonly IDifficultyService _service;

       public Difficulty Difficulty { get; set; }
        public RetrieveModel (IDifficultyService service)
        {
            _service = service; 
        }
        public void OnGet(int id)
        {
            _service.Retrieve(id);
        }
    }
}
