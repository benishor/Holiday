using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Holiday;

namespace HolidayTests
{
    public class Storage
    {
        private readonly List<HolidayRequest> requests = new List<HolidayRequest>();
        private readonly List<Employee> employees = new List<Employee>();

        private readonly Dictionary<Type, IList> lists = new Dictionary<Type, IList>();

        public Storage()
        {
            lists.Add(typeof(HolidayRequest), requests);
            lists.Add(typeof(Employee), employees);
        }

        public ICollection<T> GetStorageFor<T>()
        {
            if (lists.ContainsKey(typeof (T)))
                return lists[typeof (T)] as ICollection<T>;

            return null;
        }
        
    }
    public class DAL
    {
        private Storage storage = new Storage();
        private ICollection<HolidayRequest> requests;
        private ICollection<Employee> employees;

        public DAL()
        {
            requests = storage.GetStorageFor<HolidayRequest>();
            employees = storage.GetStorageFor<Employee>();
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