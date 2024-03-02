
using Microsoft.EntityFrameworkCore;

namespace eShop.Data.Repositories
{
    public class Repository<TEntity>(AppDbContext dbcontext)
        : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _dbcontext = dbcontext;
        private readonly DbSet<TEntity> _dbSet = dbcontext.Set<TEntity>();

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _dbcontext.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();

        }

        public TEntity GetById(int id)
        {
            var entity = _dbSet.FirstOrDefault(e => e.Id == id);
            return entity;
        }

        public void Update(TEntity entity)
        {

            _dbSet.Update(entity);
            _dbcontext.SaveChanges();
        }
    }
}
