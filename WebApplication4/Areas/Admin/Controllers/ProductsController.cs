using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Services;

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
        public IActionResult Create(Product request,IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = context.Categories.ToList();
                return View(request);

            }
            var imageService = new ImageService();
            string fileName = imageService.UploadImage(image);
            request.Image = fileName;
            context.products.Add(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var product = context.products.FirstOrDefault(x => x.Id == id);
            var imageService = new ImageService();
            imageService.DeleteImage(product.Image);

            context.products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = context.products.Find(id);
            ViewBag.Categories = context.Categories.ToList();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product request,IFormFile? image)
        {
            var exitingProduct = context.products.AsNoTracking().FirstOrDefault(p => p.Id == request.Id);
            if (image is not null)
            {
                var imageService = new ImageService();
                string fileName = imageService.UploadImage(image);
                request.Image = fileName;
                imageService.DeleteImage(exitingProduct.Image);
            }
            else
            {
                request.Image = exitingProduct.Image;

            }
            context.products.Update(request);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        


        }





    }

