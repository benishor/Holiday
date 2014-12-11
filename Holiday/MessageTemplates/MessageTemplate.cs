using System;

namespace Holiday.MessageTemplates
{
    public class MessageTemplate
    {
        public readonly string Subject = "";
        private readonly Template template;

        protected MessageTemplate(string subject, string template)
        {
            Subject = subject;
            this.template = new Template(template);
        }

        public void SetEmployeeName(string employeeName)
        {
            template.SetParameter("EmployeeName", employeeName);
        }

        public void SetManagerName(string managerName)
        {
            template.SetParameter("ManagerName", managerName);
        }

        public void SetStartDate(DateTime start)
        {
            template.SetParameter("Start", start.ToShortDateString());
        }

        public void SetEndDate(DateTime end)
        {
            template.SetParameter("End", end.ToShortDateString());
        }

        public string GetBody()
        {
            return template.Render();
        }
    }
}