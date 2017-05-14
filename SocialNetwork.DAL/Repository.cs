using System;
using System.Data.Entity;
using System.Linq;

namespace SocialNetwork.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public static Repository<T> Instance { get; } = new Repository<T>();
        private readonly DbContext _context = new AppDbContext();

        private Repository() { }

        public IQueryable<T> Entities
        {
            get => _context.Set<T>();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);

            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }

            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
