using System;

namespace Holiday
{
    public class HolidayRequest
    {
        private readonly string employee;
        private readonly string manager;
        private readonly DateTime start;
        private readonly DateTime end;

        public HolidayRequest(string employee, string manager, DateTime start, DateTime end, string type)
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
    }
}