using System;
using System.Linq;

namespace AccountingOfOverwork.Domain
{
    public interface IRepository<T> where T : Entity
    {
        T Get(Guid id);
        void Add(T entity);
        void Remove(T entity);

        IQueryable<T> AsQueryable();
    }
}