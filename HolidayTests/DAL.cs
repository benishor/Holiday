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

        public HolidayRequest CreateNewRequest(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            var newRequest = new HolidayRequest(employee, manager, start, end);
            storage.Add<HolidayRequest>(newRequest);
            return newRequest;
        }

        public IEnumerable<HolidayRequest> GetAllRequest(Employee employee)
        {
            return storage.GetStorageFor<HolidayRequest>().Where(r=>r.WasSubmittedBy(employee));
        }

        public IEnumerable<HolidayRequest> GetRequestsWaitingApproval(Employee manager)
        {
            return storage.GetStorageFor<HolidayRequest>().Where(r => r.IsWaitingApprovalBy(manager));
        }

        public Employee CreateNewEmployee()
        {
            var newEmployee = new Employee();
            storage.Add<Employee>(newEmployee);
            return newEmployee;
        }

        public Employee GetEmployeeByID(int id)
        {
            return storage.GetStorageFor<Employee>().SingleOrDefault(e => e.ID == id);
        }
    }
}