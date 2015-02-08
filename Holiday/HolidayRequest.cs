using System;

namespace Holiday
{
    public class HolidayRequest
    {
        public int ID { get; set; }
        private readonly Employee employee;
        private readonly Employee manager;
        private readonly DateTime start;
        private readonly DateTime end;

        private enum Status
        {
            Pending,
            Approved,
            Rejected
        }
        private Status status;

        public HolidayRequest()
        {
            
        }

        public HolidayRequest(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            this.employee = employee;
            this.manager = manager;
            this.start = start;
            this.end = end;
            Submit();
        }

        private void Submit()
        {
            status = Status.Pending;
            var message = Message.SubmissionMessage(employee, manager, start, end);
            message.Send();
        }

        public void Approve()
        {
            status = Status.Approved;
            var message = Message.ApprovalMessage(employee, manager, start, end);
            message.Send();
        }

        public void Reject()
        {
            status = Status.Rejected;
            var message = Message.RejectionMessage(employee, manager, start, end);
            message.Send();
        }

        public bool WasSubmittedBy(Employee anEmployee)
        {
            // TODO: is this the right way to cehck for employee equality?
            return anEmployee == employee;
        }

        public bool IsWaitingApprovalBy(Employee aManager)
        {
            // TODO: request status
            return IsWaitingApproval() && (aManager == manager);
        }

        private bool IsWaitingApproval()
        {
            return status == Status.Pending;
        }
    }
}