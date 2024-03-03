namespace eShop.BLL.Interfaces
{
    public interface IUploadService
    {
        string UploadImage(IFormFile file);
        void DeleteImage(string fileName);
    }
}
