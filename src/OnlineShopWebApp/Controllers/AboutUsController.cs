using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
