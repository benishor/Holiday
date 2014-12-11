using System;
using Holiday.MessageTemplates;

namespace Holiday
{
    public class Message : IHolidayRequestView
    {
        public string From;
        public string To;
        public string CC;

        private Template template;
        private string subject;

        public void SetEmployee(Employee employee)
        {
            template.SetParameter("EmployeeName", employee.Name);
        }

        public void SetManager(Employee manager)
        {
            template.SetParameter("ManagerName", manager.Name);
        }

        public void SetStart(DateTime start)
        {
            template.SetParameter("Start", start.ToShortDateString());
        }

        public void SetEnd(DateTime end)
        {
            template.SetParameter("End", end.ToShortDateString());
        }

        public void SetSubject(string subject)
        {
            this.subject = subject;
        }

        public void SetBodyTemplate(string bodyTemplate)
        {
            template = new Template(bodyTemplate);
        }

        public void Send()
        {
            ChannelLocator.Channel.Send(From, To, CC, subject, template.Render());
        }
    }
}