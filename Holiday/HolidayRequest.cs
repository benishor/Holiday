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
            var message = new Message(new SubmissionMessageTemplate());

            FillMessage(message);
            message.From = employee.Email;
            message.To = manager.Email;
            message.CC = Employee.HR().Email;

            message.Send();
        }

        public void Approve()
        {
            var message = new Message(new ApprovalMessageTemplate());

            FillMessage(message);
            message.From = manager.Email;
            message.To = Employee.HR().Email;
            message.CC = employee.Email;

            message.Send();
        }

        public void Reject()
        {
            var message = new Message(new RejectionMessageTemplate());

            FillMessage(message);
            message.From = manager.Email;
            message.To = employee.Email;
            message.CC = Employee.HR().Email;

            message.Send();
        }

        private void FillMessage(Message message)
        {

            message.SetEmployee(employee);
            message.SetManager(manager);
            message.SetStart(start);
            message.SetEnd(end);
        }
    }
}