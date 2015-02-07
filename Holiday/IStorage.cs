using System.Collections.Generic;

namespace Holiday
{
    public interface IStorage
    {
        ICollection<T> GetStorageFor<T>();
    }
}