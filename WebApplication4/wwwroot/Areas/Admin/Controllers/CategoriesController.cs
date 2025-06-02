using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.wwwroot.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
