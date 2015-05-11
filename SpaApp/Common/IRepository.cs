using System.Linq;

namespace SpaApp.Common
{
    public interface IRepository<T>
    {
        T Add(T item);
        bool Remove(T item);
        T Update(T item);
        IQueryable<T> Query();
        bool SaveAllChanges();
    }
}
