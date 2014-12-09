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
        private static MessageTemplate messageTemplate;

        public static Message SubmissionMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            messageTemplate = new SubmissionMessageTemplate();
            FillTemplate(employee, manager, start, end);

            return new Message
                {
                    from = employee.Email,
                    to = manager.Email,
                    cc = Employee.HR().Email,
                    subject = messageTemplate.Subject,
                    body = messageTemplate.Render()
                };
        }


        public static Message ApprovalMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            messageTemplate = new ApprovalMessageTemplate();
            FillTemplate(employee, manager, start, end);

            return new Message
                {
                    from = manager.Email,
                    to = Employee.HR().Email,
                    cc = employee.Email,
                    subject = messageTemplate.Subject,
                    body = messageTemplate.Render()
                };
        }

        public static Message RejectionMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            messageTemplate = new RejectionMessageTemplate();
            FillTemplate(employee, manager, start, end);

            return new Message
                {
                    from = manager.Email,
                    to = employee.Email,
                    cc = Employee.HR().Email,
                    subject = messageTemplate.Subject,
                    body = messageTemplate.Render()
                };
        }

        private static void FillTemplate(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            messageTemplate.SetEmployeeName(employee.Name);
            messageTemplate.SetManagerName(manager.Name);
            messageTemplate.SetStartDate(start);
            messageTemplate.SetEndDate(end);
        }

        public void Send()
        {
            ChannelLocator.Channel.Send(from, to, cc, subject, body);
        }
    }
}