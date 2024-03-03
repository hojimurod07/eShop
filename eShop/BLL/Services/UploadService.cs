using eShop.BLL.Interfaces;

namespace eShop.BLL.Services
{
    public class UploadService(IWebHostEnvironment webHostEnvironment) : IUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public void DeleteImage(string fileName)
        {
            var wrootpapkasi = _webHostEnvironment.WebRootPath;
            var imagePapkasi = wrootpapkasi + $"/{fileName}";
            if (File.Exists(imagePapkasi))
            {
                File.Delete(imagePapkasi);
            }
        }

        public string UploadImage(IFormFile file)
        {
            var wrootpapkasi = _webHostEnvironment.WebRootPath;
            var imagePapkasi = wrootpapkasi + $"/rasmlar/";
            string uniqName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = imagePapkasi + uniqName;
            using (var filestream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(filestream);

            }
            return $"rasmlar/{uniqName}";
        }


    }
}
