using WebApplication4.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication4.Services
{
    public class ImageService
    {
        private string _imageFolderPath;
        public ImageService()
        {
            _imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images");
        }
        public string UploadImage(IFormFile image)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filepath = Path.Combine(_imageFolderPath, fileName);

            using (var stream = System.IO.File.Create(filepath))
            {
                image.CopyTo(stream);
            }
            return fileName;
        }

        public bool DeleteImage(String fileName)
        {
            var fullPath = Path.Combine(_imageFolderPath, fileName);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
        
            }
            return false;
        }

    }
}
