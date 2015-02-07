using System;
using System.Collections.Generic;
using System.Linq;
using Holiday;

namespace HolidayTests
{
    public class DAL
    {
        private readonly Storage storage = new Storage();

        public HolidayRequest CreateNewRequest(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            var newRequest = new HolidayRequest(employee, manager, start, end);
            storage.GetStorageFor<HolidayRequest>().Add(newRequest);
            return newRequest;
        }

        public void UpdateRequest(HolidayRequest request)
        {
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
            storage.GetStorageFor<Employee>().Add(newEmployee);
            return newEmployee;
        }
    }
}