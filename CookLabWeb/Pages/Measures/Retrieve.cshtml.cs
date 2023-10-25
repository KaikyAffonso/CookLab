using CookLab.Model;
using CookLab.Service.Ingredients;
using CookLab.Service.Measures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookLabWeb.Pages.Measures
{
    public class RetrieveModel : PageModel
    {
        private readonly IMeasureService _service;

        public Measure Measure { get; set; }
        public User User { get; set; }

        public RetrieveModel(IMeasureService service)
        {
            _service = service;
        }

        public void OnGet(int id)
        {
            GetUser();
            Measure = _service.Retrieve(id);
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
