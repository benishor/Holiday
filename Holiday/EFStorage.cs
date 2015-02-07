using System.Data.Entity;

namespace Holiday
{
    public class EFStorage: DbContext
    {
        public DbSet<HolidayRequest> HolidayRequests { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
