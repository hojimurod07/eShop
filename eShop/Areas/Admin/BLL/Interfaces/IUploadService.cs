namespace eShop.Areas.Admin.BLL.Interfaces
{
    public interface IUploadService
    {
        string UploadImage(IFormFile file);
        void DeleteImage(string fileName);
    }
}
