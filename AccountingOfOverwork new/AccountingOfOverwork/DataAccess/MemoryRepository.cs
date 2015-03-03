using System;
using System.Collections.Generic;
using System.Linq;
using AccountingOfOverwork.Domain;

namespace AccountingOfOverwork.DataAccess
{
    public class MemoryRepository<T> : IRepository<T> where T : Entity
    {
        private readonly List<T> list = new List<T>();

        public T Get(Guid id)
        {
            return list.Find(x => x.Id == id);
        }

        public void Add(T entity)
        {
            list.Add(entity);
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> AsQueryable()
        {
            return list.AsQueryable();
        }
    }
}