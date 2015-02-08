using System.Linq;

namespace Holiday
{
    public interface IStorage
    {
        IQueryable<T> GetStorageFor<T>() where T: class;
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class ;
    }
}