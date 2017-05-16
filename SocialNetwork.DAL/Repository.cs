using System;
using System.Data.Entity;
using System.Linq;

namespace SocialNetwork.DAL
{
    public class Repository
    {
        private static readonly DbContext _dbContext = new AppDbContext();

        protected DbContext DbContext { get => _dbContext; }
    }

    public class Repository<T> : Repository, IRepository<T> where T : class
    {
        public static Repository<T> Instance { get; } = new Repository<T>();

        private Repository() { }

        public IQueryable<T> Entities
        {
            get => DbContext.Set<T>();
        }

        public void Create(T entity)
        {
            DbContext.Set<T>().Add(entity);
            DbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = DbContext.Set<T>().Find(id);

            if (entity != null)
            {
                DbContext.Set<T>().Remove(entity);
            }

            DbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
