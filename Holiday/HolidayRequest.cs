using System;

namespace Holiday
{
    public class HolidayRequest
    {
        private readonly Employee employee;
        private readonly Employee manager;
        private readonly DateTime start;
        private readonly DateTime end;

        public HolidayRequest(Employee employee, Employee manager, DateTime start, DateTime end, string type)
        {
            this.employee = employee;
            this.manager = manager;
            this.start = start;
            this.end = end;
            Submit();
        }

        private void Submit()
        {
            //var message = Message.SubmissionMessage(employee, manager, start, end);

            var message = new Message(new SubmissionMessageTemplate(), employee.Email, manager.Email, Employee.HR().Email);

            message.SetEmployee(employee);
            message.SetManager(manager);
            message.SetStart(start);
            message.SetEnd(end);


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
    }
}