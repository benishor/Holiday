using System;
using System.Collections.Generic;
using System.Linq;
using Holiday;

namespace HolidayTests
{
    public class Storage
    {
        public readonly ICollection<HolidayRequest> requests = new List<HolidayRequest>();
        public readonly ICollection<Employee> employees = new List<Employee>();
        
    }
    public class DAL
    {
        private Storage storage = new Storage();
        private ICollection<HolidayRequest> requests;
        private ICollection<Employee> employees;

        public DAL()
        {
            requests = storage.requests;
            employees = storage.employees;
        }

        public HolidayRequest CreateNewRequest(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            var newRequest = new HolidayRequest(employee, manager, start, end);
            requests.Add(newRequest);
            return newRequest;
        }

        public void UpdateRequest(HolidayRequest request)
        {
        }

        public IEnumerable<HolidayRequest> GetAllRequest(Employee employee)
        {
            return requests.Where(r=>r.WasSubmittedBy(employee));
        }

        public IEnumerable<HolidayRequest> GetRequestsWaitingApproval(Employee manager)
        {
            return requests.Where(r => r.IsWaitingApprovalBy(manager));
        }

        public Employee CreateNewEmployee()
        {
            var newEmployee = new Employee();
            employees.Add(newEmployee);
            return newEmployee;
        }
    }
}