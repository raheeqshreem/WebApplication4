using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {

        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var products = context.products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = context.Categories.ToList();

            return View();
        }


        [HttpPost]
        public IActionResult Create(Product request,IFormFile Image)
        {
            var fileName = Guid.NewGuid().ToString();
            fileName = fileName + Path.GetExtension(Image.FileName);
            var filePath =Path.Combine( Directory.GetCurrentDirectory(),@"wwwroot\images",fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                 Image.CopyTo(stream);
            }
            request.Image = fileName;
            context.products.Add(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
