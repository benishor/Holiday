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

        private MessageTemplate t;

        public Message(MessageTemplate template, string from, string to, string cc)
        {
            t = template;
            this.from = from;
            this.to = to;
            this.cc = cc;
        }

        //public static Message SubmissionMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        //{
        //    var template = new SubmissionMessageTemplate();
        //    Message result = new Message(template);
        //    result.SetEmployee(employee);
        //    result.SetManager(manager);
        //    result.SetStart(start);
        //    result.SetEnd(end);

        //    result.from = employee.Email;
        //    result.to = manager.Email;
        //    result.cc = Employee.HR().Email;
        //    result.subject = template.Subject;
        //    result.body = template.Render();

        //    return result;
        //}


        public static Message ApprovalMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            var template = new ApprovalMessageTemplate();
            Message result = new Message(template, manager.Email, Employee.HR().Email, employee.Email);
            result.SetEmployee(employee);
            result.SetManager(manager);
            result.SetStart(start);
            result.SetEnd(end);

            result.subject = template.Subject;
            result.body = template.Render();

            return result;
        }

        public static Message RejectionMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            var template = new RejectionMessageTemplate();
            Message result = new Message(template, manager.Email, employee.Email, Employee.HR().Email);
            result.SetEmployee(employee);
            result.SetManager(manager);
            result.SetStart(start);
            result.SetEnd(end);

            result.subject = template.Subject;
            result.body = template.Render();

            return result;

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
            ChannelLocator.Channel.Send(from, to, cc, t.Subject, t.Render());
        }

        public void SetEmployee(Employee employee)
        {
            t.SetEmployeeName(employee.Name);
        }

        public void SetManager(Employee manager)
        {
            t.SetManagerName(manager.Name);
        }

        public void SetStart(DateTime start)
        {
            t.SetStartDate(start);
        }

        public void SetEnd(DateTime end)
        {
            t.SetEndDate(end);
        }
    }
}