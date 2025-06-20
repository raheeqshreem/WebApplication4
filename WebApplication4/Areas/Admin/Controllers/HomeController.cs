using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.wwwroot.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();

        }
    }
}
