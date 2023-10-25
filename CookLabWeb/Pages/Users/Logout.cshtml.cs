using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookLabWeb.Pages.Users
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
                HttpContext.Session.Clear();
                return Redirect("/Index");
            
        }
    }
}
