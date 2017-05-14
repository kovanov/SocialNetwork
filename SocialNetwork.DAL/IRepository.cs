using System;
using System.Linq;

namespace SocialNetwork.DAL
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> Entities { get; }
        void Create(T item);
        void Delete(int id);
        void Update(T item);
    }
}
