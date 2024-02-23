using eShop.Data.Entites;
using eShop.Data.interfaces;

namespace eShop.Data.Repositories
{
    public class CategoryRepository(AppDbContext dbcontext) : ICategoryInterface
    {
        private readonly AppDbContext _dbcontext = dbcontext;

        public void AddCategory(Category category)
        {
            _dbcontext.Categories.Add(category);
            _dbcontext.SaveChanges();

        }

        public void DeleteCategory(int id)
        {
            var category = _dbcontext.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _dbcontext.Categories.Remove(category);
                _dbcontext.SaveChanges();
            }
        }

        public List<Category> GetCategories()
        => _dbcontext.Categories.ToList();

        public Category GetCategoryByIdd(int id)
        {
            return _dbcontext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCategory(Category category)
        {
            _dbcontext.Categories.Update(category);
            _dbcontext.SaveChanges();
        }
    }
}
