namespace eShop.Areas.Admin.Data.interfaces
{
    public interface IRepository<TEntity>
    {
        List<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        TEntity GetById(int id);
    }
}
