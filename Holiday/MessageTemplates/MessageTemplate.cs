using System;

namespace Holiday.MessageTemplates
{
    public class MessageTemplate : Template
    {
        public readonly string Subject = "";

        protected MessageTemplate(string subject, string bodyTemplate)
            : base(bodyTemplate)
        {
            Subject = subject;
        }

        public void SetEmployeeName(string employeeName)
        {
            SetParameter("EmployeeName", employeeName);
        }

        public void SetManagerName(string managerName)
        {
            SetParameter("ManagerName", managerName);
        }

        public void SetStartDate(DateTime start)
        {
            SetParameter("Start", start.ToShortDateString());
        }

        public void SetEndDate(DateTime end)
        {
            SetParameter("End", end.ToShortDateString());
        }
    }
}