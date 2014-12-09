using System;

namespace Holiday
{
    public class Message
    {
        private string from;
        private string to;
        private string cc;
        private string subject;
        private string body;

        public static Message SubmissionMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            Template t = new Template();
            t.Subject = Template.submissionMessageSubject;
            t.BodyTemplate = Template.submissionMessageBody;
            t.SetParameter("EmployeeName", employee.Name);
            t.SetParameter("Start", start.ToShortDateString());
            t.SetParameter("End", end.ToShortDateString());

            return new Message
            {
                from = employee.Email,
                to = manager.Email,
                cc = Employee.HR().Email,
                subject = t.Subject,
                body = t.Body
            };
        }


        public static Message ApprovalMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {

            Template t = new Template();
            t.Subject = Template.approvalMessageSubject;
            t.BodyTemplate = Template.approvalMessageBody;
            t.SetParameter("EmployeeName", employee.Name);
            t.SetParameter("ManagerName", manager.Name);
            t.SetParameter("Start", start.ToShortDateString());
            t.SetParameter("End", end.ToShortDateString());

            return new Message
            {
                from = manager.Email,
                to = Employee.HR().Email,
                cc = employee.Email,
                subject = t.Subject,
                body = t.Body
            };
        }

        public static Message RejectionMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            const string rejectionMessageSubject = "Cerere de concediu rejectata";
            const string rejectionMessageBody = "Subsemnatul {0} nu aprob cererea de concediu de odihna pe perioada {1} - {2} pentru {3}.";
            return new Message
            {
                from = manager.Email,
                to = employee.Email,
                cc = Employee.HR().Email,
                subject = rejectionMessageSubject,
                body = string.Format(rejectionMessageBody, manager.Name, employee.Name, start.ToShortDateString(), end.ToShortDateString())
            };
        }

        public void Send()
        {
            ChannelLocator.Channel.Send(from, to, cc, subject, body);
        }
    }

}