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
            FillMessage(message, from: employee.Email, to: manager.Email, cc: Employee.HR().Email);
            message.Send();
        }

        public void Approve()
        {
            var message = new Message(new ApprovalMessageTemplate());
            FillMessage(message, from: manager.Email, to: Employee.HR().Email, cc: employee.Email);
            message.Send();
        }

        public void Reject()
        {
            var message = new Message(new RejectionMessageTemplate());
            FillMessage(message, from: manager.Email, to: employee.Email, cc: Employee.HR().Email);
            message.Send();
        }

        private void FillMessage(Message message, string from, string to, string cc)
        {
            message.SetFrom(from);
            message.SetTo(to);
            message.SetCC(cc);

            message.SetEmployee(employee);
            message.SetManager(manager);
            message.SetStart(start);
            message.SetEnd(end);
        }
    }
}