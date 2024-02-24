namespace eShop.BLL.Interfaces
{
    public interface IImageService
    {
        string UploadImage(IFormFile file);
        void DeleteImage(string fileName);
    }
}
