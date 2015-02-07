using System.Collections.Generic;

namespace HolidayTests
{
    public interface IStorage
    {
        ICollection<T> GetStorageFor<T>();
    }
}