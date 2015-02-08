using System;
using System.Collections.Generic;
using System.Linq;
using Holiday;

namespace HolidayTests
{
    public class DAL
    {
        private readonly IStorage storage;

        public DAL()
            :this(new Storage())
        {
            
        }

        public DAL(IStorage storage)
        {
            this.storage = storage;
        }

        public IEnumerable<HolidayRequest> GetAllRequest(Employee employee)
        {
            return storage.GetStorageFor<HolidayRequest>().Where(r=>r.WasSubmittedBy(employee));
        }

        public IEnumerable<HolidayRequest> GetRequestsWaitingApproval(Employee manager)
        {
            return storage.GetStorageFor<HolidayRequest>().Where(r => r.IsWaitingApprovalBy(manager));
        }

        public void AddEmployee(Employee employee)
        {
            storage.Add(employee);
        }

        public Employee GetEmployeeByID(int id)
        {
            return storage.GetStorageFor<Employee>().SingleOrDefault(e => e.ID == id);
        }

        public void AddRequest(HolidayRequest request)
        {
            storage.Add(request);
        }

        public HolidayRequest GetRequestByID(int id)
        {
            return storage.GetStorageFor<HolidayRequest>().SingleOrDefault(r => r.ID == id);
        }
    }
}