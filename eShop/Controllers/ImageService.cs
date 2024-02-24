using eShop.BLL.Interfaces;

namespace eShop.Controllers
{
    public class ImageService(IWebHostEnvironment webHostEnvironment) : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public void DeleteImage(string fileName)
        {
            var wwwrootfolder = _webHostEnvironment.WebRootPath;
            var filePath = Path.Combine(wwwrootfolder, fileName.Replace("~/", ""));
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string UploadImage(IFormFile file)
        {
            var wwwrootfolder = _webHostEnvironment.WebRootPath;
            var uniqFileName = Guid.NewGuid().ToString() + "_" + file.Name;
            var filePath = Path.Combine(wwwrootfolder + "/images/", uniqFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return $"~/images/{uniqFileName}";
        }
    }
}
