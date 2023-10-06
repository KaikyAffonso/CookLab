using CookLab.Service.Difficulties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Difficulties
{
    public class DeleteModel : PageModel
    {
        private readonly IDifficultyService _service;
        public DeleteModel (IDifficultyService service)
        {
            _service = service; 
        }
        public IActionResult OnGet(int id)
        {
            _service.Delete(id);
            return Redirect("/Difficulties/Difficulty"); 
        }
    }
}
