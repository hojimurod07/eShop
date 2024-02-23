using eShop.Data.Entites;

namespace eShop.Data.interfaces
{
    public interface ICategoryInterface
    {
        List<Category> GetCategories();
        Category GetCategoryByIdd(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
