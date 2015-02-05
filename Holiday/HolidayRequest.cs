using System;

namespace Holiday
{
    public class HolidayRequest
    {
        private readonly Employee employee;
        private readonly Employee manager;
        private readonly DateTime start;
        private readonly DateTime end;

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
            var message = Message.SubmissionMessage(employee, manager, start, end);
            message.Send();
        }

        public void Approve()
        {
            var message = Message.ApprovalMessage(employee, manager, start, end);
            message.Send();
        }

        public void Reject()
        {
            var message = Message.RejectionMessage(employee, manager, start, end);
            message.Send();
        }

        public bool WasSubmittedBy(Employee anEmployee)
        {
            // TODO: is this the right way to cehck for employee equality?
            return anEmployee == employee;
        }
    }
}