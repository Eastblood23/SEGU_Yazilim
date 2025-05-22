using Microsoft.AspNetCore.Mvc;

namespace SEGU__site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
