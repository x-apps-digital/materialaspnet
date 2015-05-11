using System.Collections.Generic;
using System.Linq;

namespace SpaApp.Common
{
    public class ListRepository<T> : IRepository<T>
    {
        public T Add(T item)
        {
            _data.Add(item);
            return item;
        }

        public bool Remove(T item)
        {
            return _data.Remove(item);
        }

        public T Update(T item)
        {
            return item;
        }

        public IQueryable<T> Query()
        {
            return _data.AsQueryable();
        }

        public bool SaveAllChanges()
        {
            return true;
        }

        public ListRepository()
        {
            _data = new List<T>();
        }

        private readonly List<T> _data;
    }
}