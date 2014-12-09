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
            var template = new SubmissionMessageTemplate(employee.Name, manager.Name, start.ToShortDateString(), end.ToShortDateString());

            return new Message
                {
                    from = employee.Email,
                    to = manager.Email,
                    cc = Employee.HR().Email,
                    subject = template.Subject,
                    body = template.Body
                };
        }


        public static Message ApprovalMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            Template t = new ApprovalMessageTemplate(employee.Name, manager.Name, start.ToShortDateString(), end.ToShortDateString());

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
            var t = new RejectionMessageTemplate(employee.Name, manager.Name, start.ToShortDateString(), end.ToShortDateString());

            return new Message
                {
                    from = manager.Email,
                    to = employee.Email,
                    cc = Employee.HR().Email,
                    subject = t.Subject,
                    body = t.Body
                };
        }

        public void Send()
        {
            ChannelLocator.Channel.Send(from, to, cc, subject, body);
        }
    }
}