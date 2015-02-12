using System.Collections.Generic;
using System.Linq;

namespace Holiday
{
    public class DAL
    {
        private readonly IStorage storage;

        public DAL(IStorage storage)
        {
            this.storage = storage;
        }

        public IEnumerable<HolidayRequest> GetAllRequest(Employee employee)
        {
            return storage.GetStorageFor<HolidayRequest>().Where(r=>r.employee.ID == employee.ID);
        }

        public IEnumerable<HolidayRequest> GetRequestsWaitingApproval(Employee manager)
        {
            return storage.GetStorageFor<HolidayRequest>().Where(r => (r.status == Status.Pending) && (r.manager.ID == manager.ID));
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

        // CR: I'm not sure about separating persistence from the object behaviour. 
        // I mean, if the request is responsible for actually sending the email messages why is not also responsible for
        // saving its state when submitting/approving/rejecting? Where do we draw the line? I don't necessarily consider this
        // a problem but a question worth discussing.
        public void ApproveRequest(HolidayRequest request)
        {
            request.Approve();
            storage.Update(request);
        }

        public void RejectRequest(HolidayRequest request)
        {
            request.Reject();
            storage.Update(request);
        }
    }
}