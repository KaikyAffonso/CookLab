using CookLab.Model;
using CookLab.Service.Ingredients;
using CookLab.Service.Measures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Measures
{
    public class UpdateModel : PageModel
    {
        private readonly IMeasureService _service;

        public Measure Measure { get; set; }
        public User User { get; set; }
        public UpdateModel(IMeasureService service)
        {
            _service = service;
        }
        public void OnGet(int id)
        {
            GetUser();
            Measure = _service.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Measure measure = new Measure();

            measure.Id = Convert.ToInt32(Request.Form["id"]);
            measure.Name = Convert.ToString(Request.Form["name"]);
            _service.Update(measure);

            return Redirect("/Measures/Measure");

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
