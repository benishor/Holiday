using System;
using System.Collections.Generic;
using System.Linq;
using Holiday;

namespace HolidayTests
{
    public class DAL
    {
        private readonly ICollection<HolidayRequest> requests = new List<HolidayRequest>();

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
    }
}