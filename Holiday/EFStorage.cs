using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Holiday
{
    public class EFStorage: DbContext, IStorage
    {
        public DbSet<HolidayRequest> HolidayRequests { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public EFStorage()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFStorage>());
        }

        public IQueryable<T> GetStorageFor<T>() where T : class
        {
            return Set<T>();
        }

        public void Add<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }
    }
}
