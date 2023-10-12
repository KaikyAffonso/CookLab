using CookLab.Service.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly IUserService _service;

        public DeleteModel(IUserService service)
        {
            _service = service;
        }
        public IActionResult OnGet(int id)
        {

            _service.Delete(id);
            return Redirect("/Users/User");
        }
    }
}
